using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InGame;
public class EnemyDeadState : FSM.FSMState
{
    public override ActorState actorState => ActorState.Dead;

    public override void OnStart()
    {
        Debug.Log("OnUpdate Enemy OnStart");
    }

    public override void OnUpdate()
    {
        Debug.Log("OnUpdate Enemy OnUpdate");
    }

    public override void OnLateUpdate()
    {

    }


    public override void OnEnd()
    {
        Debug.Log("OnUpdate Enemy OnEnd");
    }
}
