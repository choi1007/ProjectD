using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data.Weapon;
using MarchingBytes;

public class WeaponRifle : WeaponBase
{
    public override void InitWeapon(uint _weaponId, Player _player)
    {
        this.WeaponDataBase.InitWeaponData(_weaponId);
        Player = _player;
    }

    public override bool Fire()
    {
        if (Bullet == 0) return false;

        AttackRateTime += Time.deltaTime;
        if (AttackRateTime > WeaponDataBase.AttackRate)
        {

            AttackRateTime = 0;
            Bullet--;
            EasyObjectPool.instance.GetObjectFromPool("BulletEffect", WeaponBulletEffect.position, Player.transform.rotation);
            if (EffectObject.activeSelf) EffectObject.SetActive(false);
            EffectObject.SetActive(true);
        }
        return true;
    }

    public override void Realod()
    {
        Bullet = WeaponDataBase.BulletCount;
    }
}
