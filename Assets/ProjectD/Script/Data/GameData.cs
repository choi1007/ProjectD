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
        public uint WeaponId; // 무기아이디.
        public int Damage; // 대미지.
        public float AttackRate; // 쏘는간격. 
        public float Critical; // 크리티컬.
        public float ReloadTime; // 재장전시간.
        public int AccuracyRate; // 명중률.
        public int MagazineBullet; //탄창의 총알수.
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