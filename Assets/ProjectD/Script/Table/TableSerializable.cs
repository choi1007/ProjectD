using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TableData
{
    [Serializable]
    public class CharSheet : CharData
    {
        public uint CharId;
        public bool Default;
    }

    [Serializable]
    public class CharUpgradeSheet : CharData
    {
        public int Level;
        public int SkillPoint;
    }

    public class CharData
    {
        public int Hp;
        public float Speed;
    }

    [Serializable]
    public class LevelExpSheet
    {
        public int Level;
        public int Exp;
    }

    [Serializable]
    public class SkillSheet : Skill
    {
        public enum Type
        {
            Buff,
            Active,
            DeBuff
        }

        public Type SkillType;
    }

    [Serializable]
    public class SkillUpgradeSheet : Skill
    {
        public int Level;
    }

    public class Skill
    {
        public uint Id;
        public float Value;
        public float ActiveTime;
        public float CoolTime;
    }


    [Serializable]
    public class ItemSheet
    {
        public enum Type
        {
            Item,
            Bullet,
            Material,
        }

        public uint Id;
        public Type ItemType;
        public float Weight;
        public uint CombineId;
    }

    public class ItemCombineSheet
    {
        public uint Id;
        public uint MaterialId;
        public int Amount;
    }
}