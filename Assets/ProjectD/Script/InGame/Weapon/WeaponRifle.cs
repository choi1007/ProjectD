using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameData;
using MarchingBytes;

public class WeaponRifle : WeaponBase
{
    public override void InitWeapon(uint _weaponId, Player _player)
    {
        WeaponData _weaponData = new WeaponData();
        _weaponData.Damage = 10;
        _weaponData.AttackRate = 0.15f;
        _weaponData.Critical = 50;
        _weaponData.ReloadTime = 2f;
        _weaponData.AccuracyRate = 80;
        _weaponData.MagazineBullet = 30;
        WeaponData = _weaponData;
        Bullet = WeaponData.MagazineBullet;
        Player = _player;
    }

    public override bool Fire()
    {
        if (Bullet == 0) return false;

        AttackRateTime += Time.deltaTime;
        if (AttackRateTime > WeaponData.AttackRate)
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
        Bullet = WeaponData.MagazineBullet;
    }
}
