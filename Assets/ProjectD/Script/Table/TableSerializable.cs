using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TableData
{
    [Serializable]
    public class CharUpgradeSheet
    {
        public int Level;
        public int Hp;
        public int Skill;
    }

    [Serializable]
    public class UpgradeMaterialSheet
    {
        public int Level;
        public int Iron;
        public int Cloth;
        public int Junk;
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
        public int MaxAmount;
        public float Weight;
        public Type ItemType;
    }

    [Serializable]
    public class SkillSheet
    {
        public uint Id;
        public int Value1;
        public int Value2;
        public int Value3;
    }
}