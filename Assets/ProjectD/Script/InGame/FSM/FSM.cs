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
        Idle = 0,
        Move,
        Dead,
        Attack,
        Skill,
        DropItem,
        Reload,
    }

    public sealed partial class FSM : MonoBehaviour
    {
        public Actor actor;

        public LayerMask EnemyLayers;

        public Actor target { get; set; }

        public ActorState state { get; private set; }

        private Dictionary<ActorState, FSMState> dicStates = new Dictionary<ActorState, FSMState>();

        [SerializeField] private Animator animator;

        private void Awake()
        {
            if (actor == null)
                actor = GetComponent<Actor>();
        }

        private void Update()
        {
            GetCurState()?.OnUpdate();
        }

        private void LateUpdate()
        {
            GetCurState()?.OnLateUpdate();
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
        }

        public void PlayAnimation(string _animKey, bool _animActive = false)
        {
            if (animator == null) return;
            if (String.IsNullOrEmpty(_animKey) == false)
                animator.SetBool(_animKey, _animActive);
        }

        public void PlayAnimation(string _animKey, float _animActive = 0)
        {
            if (animator == null) return;
            if (String.IsNullOrEmpty(_animKey) == false)
                animator.SetFloat(_animKey, _animActive);
        }
    }
}
