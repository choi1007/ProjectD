using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InGame;

public class PlayerGetItemState : FSM.FSMState
{
    public override ActorState actorState => ActorState.DropItem;

    public override void OnStart()
    {
        Debug.Log("OnStart PlayerDropItemState");
        fsm.PlayAnimation("GetItem", true);
    }

    public override void OnUpdate()
    {
        Debug.Log("OnUpdate PlayerDropItemState");
    }

    public override void OnLateUpdate() { }

    public override void OnEnd()
    {
        Debug.Log("OnEnd PlayerDropItemState");
        fsm.PlayAnimation("GetItem", false);
    }
}
