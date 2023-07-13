using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InGame;

public class PlayerDeadState : FSM.FSMState
{
    public override ActorState actorState => ActorState.Dead;

    public override void OnStart()
    {

    }

    public override void OnUpdate()
    {

    }

    public override void OnLateUpdate() { }

    public override void OnEnd()
    {

    }
}
