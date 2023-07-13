using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using InGame;

public class EnemyMoveState : FSM.FSMState
{
    private Vector3 OriginPos = new Vector3(); // 다시원점으로 되돌아갈때.

    public override ActorState actorState => ActorState.Move;

    private Actor Target;
    private IAstarAI Astar;

    private float AttackDistance;
    private float TargetDistance;

    private float TargetMissTime;

    public override void OnStart()
    {   
        Target = fsm.target;
        Astar = actor.Astar;
        AttackDistance = actor.AttackDistance;
        Astar.onSearchPath += OnUpdate;
    }

    public override void OnUpdate()
    {
        if (Target != null) OnTargetChase();
        if (OnTargetMissCheck()) TargetMiss();
    }

    private void OnTargetChase()
    {
        TargetDistance = Vector3.Distance(actor.transform.position, Target.transform.position);
        var _attackCheck = TargetDistance < AttackDistance;
        if (_attackCheck)
        {
            fsm.ChangeState(ActorState.Attack);
            return;
        }
        Astar.destination = Target.transform.position;
        if (Astar.hasPath) fsm.PlayAnimation("Walk", Astar.remainingDistance);
    }

    private bool OnTargetMissCheck()
    {



        return false;
    }

    private void TargetMiss()
    {

    }

    public override void OnLateUpdate()
    {

    }

    public override void OnEnd()
    {
        Astar.onSearchPath -= OnUpdate;
    }
}
