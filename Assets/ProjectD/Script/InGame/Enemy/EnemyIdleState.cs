using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InGame;

public class EnemyIdleState : FSM.FSMState
{
    public override ActorState actorState => ActorState.Idle;

    private Collider[] EnemyArray = new Collider[10];

    private Scan EnemyScanCheck;

    private float ScanDistance;

    public override void OnStart()
    {
        if(EnemyScanCheck == null)
        {
            EnemyScanCheck = new Scan();
            EnemyScanCheck.InitScan(1f);
        }

        ScanDistance = 10f;
    }

    public override void OnUpdate()
    {
        if (fsm.target == null) ScanCheck();
    }

    public override void OnLateUpdate() { }

    private void ScanCheck()
    {
        if (EnemyScanCheck.ScanCheck())
        {
            fsm.target = ScanEnemy();
            if (fsm.target != null)
                fsm.ChangeState(ActorState.Move);
        }
    }

    private Actor ScanEnemy()
    {
        var _enemyEnterCount = Physics.OverlapSphereNonAlloc(actor.transform.position, ScanDistance, EnemyArray, fsm.EnemyLayers, QueryTriggerInteraction.Collide);

        GameObject _enemy = null;
        float _distance = ScanDistance + 1f; // 초기값은 스캔값보다 살짝 커서 비교가능하게끔.

        for (int i = 0; i < _enemyEnterCount; ++i)
        {
            var _enemyCollider = EnemyArray[i];
            var _newEnemyScanDistance = Vector3.Distance(actor.transform.position, _enemyCollider.transform.position);
            if (_newEnemyScanDistance > _distance) continue;
            _distance = _newEnemyScanDistance;
            _enemy = _enemyCollider.gameObject;
        }
        return _enemy != null ? _enemy.GetComponent<Actor>() : null;
    }

    public override void OnEnd()
    {

    }
}
