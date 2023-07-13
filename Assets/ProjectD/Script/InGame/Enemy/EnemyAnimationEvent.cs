using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InGame;

public class EnemyAnimationEvent : MonoBehaviour
{
    [SerializeField] private Actor EnemyActor;

    private float AttackRateTime;
    private float AttackRate;

    private bool Attack;

    private void Awake()
    {
        AttackRate = 1f;
    }

    private void Update()
    {
        AttackRateTime += Time.deltaTime;
        if (AttackRateTime > AttackRate)
        {
            AttackRateTime = 0;
            Attack = true;
        }
    }


    public void AttackAnimEvent()
    {
        if (Vector3.Distance(transform.position, EnemyActor.Fsm.target.transform.position) < EnemyActor.AttackDistance && Attack)
        {
            Attack = false;
            Debug.Log("AttackAnimEvent");
        }
    }
}
