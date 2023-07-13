using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InGame;

public class PlayerSkillState : FSM.FSMState
{
    public override ActorState actorState => ActorState.Skill;

    public override void OnStart()
    {
        //스킬표시.
    }

    public override void OnUpdate()
    {
        // 스킬끝나고 상태 변환.
    }

    public override void OnLateUpdate() { }

    public override void OnEnd()
    {
    
    }
}
