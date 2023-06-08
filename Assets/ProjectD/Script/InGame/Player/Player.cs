using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InGame;

public class Player : Actor
{
    [SerializeField] private AISensor Scan;
    
    public void InitPlayerData()
    {
        Fsm.ChangeState(ActorState.Idle);
    }

    private void Update()
    {
        Scan.Scan();
    }

    public override void Attack()
    {

    }

    public override void Hit(int _damage)
    {

    }
}
