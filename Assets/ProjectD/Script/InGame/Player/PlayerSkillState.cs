using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InGame;

public class PlayerSkillState : FSM.FSMState
{
    public override ActorState actorState => ActorState.Skill;

    public override void OnStart()
    {
        //��ųǥ��.
    }

    public override void OnUpdate()
    {
        // ��ų������ ���� ��ȯ.
    }

    public override void OnLateUpdate() { }

    public override void OnEnd()
    {
    
    }
}
