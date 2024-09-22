using System;
using UnityEngine;
using DataEnum;

namespace Data.Weapon
{
    [Serializable]
    public class WeaponPos
    {
        public eWeaponPosType AnimType;
        public Quaternion Rot;
        public Vector3 Pos;
    }

    public interface IWeaponData
    {
        public int Damage
        {
            get;
        }

        public float AttackRate
        {
            get;
        }

        public float ReloadTime
        {
            get;
        }

        public int BulletCount
        {
            get;
        }
    }

    public interface IWeaponUpgradeData
    {
        public byte Level
        {
            get;
        }
    }

    public abstract class WeaponData : BaseData, IWeaponData
    {
        private int _damage;
        private float _attackRate;
        private float _reloadTime;
        private int _bulletCount;

        public int Damage
        {
            get => _damage;
        }

        public float AttackRate
        {
            get => _attackRate;
        }

        public float ReloadTime
        {
            get => _reloadTime;
        }
    
        public int BulletCount
        {
            get => _bulletCount;
        }

        /// <summary>
        /// TID (테이블아이디) / SID (서버에서 주는 아이디)로 구분
        /// 현재는 TID만 (SID가 있다면 찾아야됨)
        /// </summary>
        /// <param name="id"></param>
        public virtual void InitWeaponData(uint id)
        {
            TID = id;
            _damage = 10;
            _attackRate = 0.2f;
            _reloadTime = 1f;
            _bulletCount = 30;
        }
    }
}