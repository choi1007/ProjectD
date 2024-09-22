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
        /// TID (���̺���̵�) / SID (�������� �ִ� ���̵�)�� ����
        /// ����� TID�� (SID�� �ִٸ� ã�ƾߵ�)
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