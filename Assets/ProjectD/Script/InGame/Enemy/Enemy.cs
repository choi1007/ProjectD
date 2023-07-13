using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using InGame;
using Pathfinding;

public class Enemy : Actor
{
    private void Awake()
    {
        Astar = GetComponent<IAstarAI>();
    }

    private void Start()
    {
        InitEnemy();
    }

    public void InitEnemy()
    {
        FSM.FSMState.Regist(new EnemyIdleState(), Fsm);
        FSM.FSMState.Regist(new EnemyMoveState(), Fsm);
        FSM.FSMState.Regist(new EnemyAttackState(), Fsm);
        FSM.FSMState.Regist(new EnemyDeadState(), Fsm);
        Fsm.ChangeState(ActorState.Idle);
    }

    public override void Hit(Damage _damage)
    {

    }
}
