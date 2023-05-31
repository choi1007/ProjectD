using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InGame;

public class PlayerAttackState : FSM.FSMState
{
    public override ActorState actorState => ActorState.Attack;

    public override void OnStart()
    {
        if (fsm.target == null)
        {
            fsm.ChangeState(ActorState.Idle);
            return;
        }
    }

    public override void OnUpdate()
    {
        if(fsm.target == null)
        {
            fsm.ChangeState(ActorState.Idle);
            return;
        }

        if(IsAttackAble())
        {
            fsm.ChangeState(ActorState.Attack);
            return;
        }
    }

    public override void OnEnd()
    {

    }
}
