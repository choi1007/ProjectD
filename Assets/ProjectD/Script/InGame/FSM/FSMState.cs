using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InGame
{
    public partial class FSM
    {
        public abstract class FSMState
        {
            protected FSM fsm;
            protected Actor actor => fsm.actor;

            public abstract ActorState actorState { get; }

            public static void Regist(FSMState fsmState, FSM fsm)
            {
                fsmState.fsm = fsm;
                fsm.dicStates.Add(fsmState.actorState, fsmState);
            }

            public abstract void OnStart();
            public abstract void OnUpdate();
            public abstract void OnEnd();

            protected bool IsInAttackRange()
            {
                if (fsm.target == null) return false;
                float _dis = Vector3.Distance(actor.transform.position, fsm.target.transform.position);
                if (_dis > actor.AttackDist) return false;
                return true;
            }

            protected bool IsAttackAble()
            {
                if (IsInAttackRange() == false) return false;
                if (actor.IsRange && actor.BulletReady() == false) return false;
                return true;
            }
        }
    }
}