using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InGame;

public class EnemyAttackState : FSM.FSMState
{
    public override ActorState actorState => ActorState.Attack;

    private Actor Target;
    private float AttackDistance;

    public override void OnStart()
    {
        Target = fsm.target;
        AttackDistance = actor.AttackDistance;
    }

    public override void OnUpdate()
    {
        var _distance = Vector3.Distance(actor.transform.position, Target.transform.position);
        fsm.PlayAnimation("Attack", _distance < AttackDistance);
        if (_distance > AttackDistance)
            fsm.ChangeState(ActorState.Move);

    }

    public override void OnLateUpdate()
    {

    }

    public override void OnEnd()
    {

    }
}
