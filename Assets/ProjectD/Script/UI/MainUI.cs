using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    [SerializeField] private Transform MainPanel;
    [SerializeField] private Transform InteractionPanel;

    private ItemBoxLootUI ItemBoxLootUIObject;


    public void InitMainUI()
    {

    }

    public void LooptItemUI(ItemEventBase _box, bool _in)
    {
        if (_in == false)
        {
            ItemBoxLootUIObject?.gameObject.SetActive(false);
            return;
        }

        if (ItemBoxLootUIObject == null)
        {
            ItemBoxLootUIObject = Util.GetPrefab<ItemBoxLootUI>("Prefabs/UIElement/ItemLootUI");
            ItemBoxLootUIObject.transform.SetParent(InteractionPanel, false);
        }
        ItemBoxLootUIObject.InitItemData(_box);
        ItemBoxLootUIObject.gameObject.SetActive(true);
    }
}
