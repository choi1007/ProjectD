using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameData;

namespace Item
{
    public abstract class Item
    {
        public bool Get { get; protected set; }
        public ItemData Data { get; protected set; }
        public virtual void ItemInit(uint _id) { }
        public virtual void ItemUse(int _amount) { }
        public virtual void ItemDelete(int _amount) { }
    }
}