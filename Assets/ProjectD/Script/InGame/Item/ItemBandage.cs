using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameData;

public class ItemBandage : Item.Item
{
    public override void ItemInit(uint _id)
    {
        // Ã£±â.
        ItemData _item = new ItemData();
        //_item.ItemID = 
        Data = _item;
        Get = Data.ItemAmount > 0;
    }

    public override void ItemUse(int _amount)
    {

    }

    public override void ItemDelete(int _amount)
    {
        Data.ItemAmount -= _amount;
        Get = Data.ItemAmount > 0;

    }
}
