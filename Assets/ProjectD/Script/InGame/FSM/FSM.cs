using System;
using System.Collections;
using System.Collections.Generic;
//using Sirenix.OdinInspector;
using System.Linq;
using UnityEngine;
//using Elendow.SpritedowAnimator;

namespace InGame
{
    public enum ActorState
    {
        Idle= 0,
        Move,
        Dead,
        Attack,
        Reload,
        Skill,
        DropItem,
    }

    public sealed partial class FSM : MonoBehaviour
    {
        public Actor actor;

        //[ShowInInspector, DisableInEditorMode]
        public Actor target { get; set; }

        //[ShowInInspector, ReadOnly]
        public ActorState state { get; private set; }

        //[ShowInInspector, ReadOnly]
        private Dictionary<ActorState, FSMState> dicStates = new Dictionary<ActorState, FSMState>();

        [SerializeField] private Animator animator;

        private void Awake()
        {
            if (actor == null)
                actor = GetComponent<Actor>();
            SetData();
        }

        private void SetData()
        {
            FSMState.Regist(new PlayerIdleState(), this);
            FSMState.Regist(new PlayerAttackState(), this);
            FSMState.Regist(new PlayerMoveState(), this);
        }

        private FSMState GetCurState()
        {
            if (this.dicStates.TryGetValue(this.state, out FSMState curState) == false) return null;
            return curState;
        }

        public void ChangeState(ActorState nextState)
        { 
            GetCurState()?.OnEnd();
            this.state = nextState;
            var newState = this.dicStates[nextState];
            newState?.OnStart();
            PlayAnimation();
        }

        public void PlayAnimation()
        {
            if (animator == null) return;

            string _animationName = "Idle";

            switch(state)
            {
                case ActorState.Idle:
                    _animationName = "Idle";
                    break;
                case ActorState.Move:
                    _animationName = "Move";
                    break;
                case ActorState.Attack:
                    _animationName = "Attack";
                    break;
            }

            animator.Play(_animationName);
        }
    }
}
