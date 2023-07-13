using System;
using System.Collections.Generic;

namespace GameData
{
    [Serializable]
    public class PlayerData
    {
        public WeaponData WeaponData;
        public CharData CharData;
        public List<SkillData> SkillData;
    }

    public class CharData
    {
        public uint CharId;
        public int MaxHp;
        public float Speed;
    }

    public class SkillData
    {
        public uint SkillId;
        public int SkillLevel;
    }

    public class Inventory
    {
        public int Magazine;
    }

    public class WeaponData
    {
        public uint WeaponId; // ������̵�.
        public int Damage; // �����.
        public float AttackRate; // ��°���. 
        public float Critical; // ũ��Ƽ��.
        public float ReloadTime; // �������ð�.
        public int AccuracyRate; // ���߷�.
        public int MagazineBullet; //źâ�� �Ѿ˼�.
        public List<WeaponUpgrade> WeaponUpgradeList = new List<WeaponUpgrade>(5);
    }

    public class WeaponUpgrade
    {
        public uint WeaponUpgradeId;
        public int WeaponUpgradeLevel;
    }

    public class ItemData
    {
        public uint ItemId;
        public int Amount;
        public float Weight;
    }
}