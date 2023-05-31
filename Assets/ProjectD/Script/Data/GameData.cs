using System;
using System.Collections.Generic;

namespace GameData
{
    [Serializable]
    public class PlayerData : CharData
    {
        public List<SkillData> SkillData;
    }

    [Serializable]
    public class NpcData : CharData
    {
        public uint NpcID;
        public SkillData SkillData;
    }

    public class MonsterData :CharData
    {
        public uint MonsterID;
        public SkillData SkillData;
    }

    public class CharData
    {
        public int Hp;
        public int Ap;
        public float AttackRate;
        public float ReloadTime;
    }

    public class SkillData
    {
        public uint SkillId;
        public int SkillLevel;
    }

    [Serializable]
    public class InventoryData
    {
        public List<ItemData> Item;
        public int InventoryLevel;
    }

    public class ItemData
    {
        public uint ItemID;
        public int ItemAmount;
        public float ItemWeight;
    }

    [Serializable]
    public class BaseData
    {
        public int BaseLevel;
        public int WallLevel;
        public int EnergyLevel;
        public int TentLevel;
    }
}