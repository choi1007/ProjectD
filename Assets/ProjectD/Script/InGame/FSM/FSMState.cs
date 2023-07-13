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
            public abstract void OnLateUpdate();
            public abstract void OnEnd();
        }
    }
}