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
        // ui �����.
    }

    public override void OnUpdate()
    {
        // �¾����� ���.
        // �ð������� uiǥ��.
    }

    public override void OnEnd()
    { 
        // drop ������ ���⼭ state������ ǥ��.
    }
}
