using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InGame;
using Data;

public class ItemBoxDialog : DialogBase
{
    [SerializeField] private Transform ItemParent; 
    
    public static ItemBoxDialog DoModal(List<ItemData> _itemList)
    {
        ItemBoxDialog Dialog = Util.GetPrefab<ItemBoxDialog>("Prefabs/Dialog/ItemBoxDialog");
        Dialog.SetData(_itemList);
        Dialog.Show();
        return Dialog;
    }

    public void SetData(List<ItemData> _itemList)
    {

    }
}
