using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InGame;

public class PlayerDropItemState : FSM.FSMState
{
    public override ActorState actorState => ActorState.DropItem;

    public override void OnStart()
    {
        // todo 
        // ui 띄워줌.
    }

    public override void OnUpdate()
    {
        // 맞았을시 취소.
        // 시간지나는 ui표시.
    }

    public override void OnEnd()
    { 
        // drop 끝날떄 여기서 state끝나는 표시.
    }
}
