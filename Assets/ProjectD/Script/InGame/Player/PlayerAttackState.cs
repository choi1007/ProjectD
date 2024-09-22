using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InGame;
using Data;
using Data.Weapon;

public class PlayerAttackState : FSM.FSMState
{
    private WeaponBase _playerWeapon = null;
    private float _reloadTime = 0;
    private float _attackRateTime = 0;

    public WeaponBase PlayerWeapon
    {
        get => _playerWeapon;
        set => _playerWeapon = value;
    }

    public float ReloadTIme
    {
        get => _reloadTime;
        set => _reloadTime = value;
    }

    public float AttackRateTime
    {
        get => _attackRateTime;
        set => _attackRateTime = value;
    }

    private Vector3 TargetLookVec = new Vector3();

    public override ActorState actorState => ActorState.Attack;

    public PlayerAttackState(WeaponBase weapon)
    {
        _playerWeapon = weapon;
    }


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
        if (_playerWeapon.Fire() == false)
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
        if (ReloadTIme > _playerWeapon.WeaponDataBase.ReloadTime)
        {
            ReloadTIme = 0;
            _playerWeapon.Realod();
        }
    }

    private void ChangeHandGun()
    {

    }

    public override void OnEnd()
    {

    }
}
