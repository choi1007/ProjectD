using System;
using System.Collections.Generic;

namespace Data
{

    [Serializable]
    public class PlayerData
    {
        public WeaponBase Weapon;
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

    public class ItemData
    {
        public uint ItemId;
        public int Amount;
        public float Weight;
    }
}