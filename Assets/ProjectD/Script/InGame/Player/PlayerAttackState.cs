using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InGame;
using GameData;

public class PlayerAttackState : FSM.FSMState
{
    public PlayerAttackState(WeaponBase _weapon)
    {
        m_weapon = _weapon;
        m_weaponData = m_weapon.WeaponData;
    }

    public WeaponBase m_weapon { get; private set; }
    private WeaponData m_weaponData;

    public float ReloadTIme;
    public float AttackRateTime;

    private Vector3 TargetLookVec = new Vector3();

    public override ActorState actorState => ActorState.Attack;

    public override void OnStart()
    {

    }

    public override void OnUpdate()
    {
        if (fsm.target == null)
        {
            fsm.ChangeState(ActorState.Idle);
            return;
        }

        Attack();
    }

    public override void OnLateUpdate()
    {
        TargetLook();
    }

    private void TargetLook()
    {
        Vector3 targetDir = fsm.target.transform.position - actor.transform.position;
        TargetLookVec.x = targetDir.x;
        TargetLookVec.z = targetDir.z;
        actor.transform.forward = TargetLookVec;
    }

    private void Attack()
    {
        if (m_weapon.Fire() == false)
            Reload();
    }

    private void Reload()
    {
        // 총알없으면 핸드건으로 변경.
        //if(m_weaponData.MagazineBullet == 0)
        //{
        //    ChangeHandGun();
        //    return;
        //}

        ReloadTIme += Time.deltaTime;
        if (ReloadTIme > m_weaponData.ReloadTime)
        {
            ReloadTIme = 0;
            m_weapon.Realod();
        }
    }

    private void ChangeHandGun()
    {

    }

    public override void OnEnd()
    {

    }
}
