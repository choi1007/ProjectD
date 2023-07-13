using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerCheck : MonoBehaviour
{



    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.layer)
        {
            case 6:
                {
                    var _itemBase = other.GetComponent<ItemEventBase>();
                    InGameManager.Instance.MainUI.LooptItemUI(_itemBase, true);
                }
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch(other.gameObject.layer)
        {
            case 6:
                {
                    var _itembase = other.GetComponent<ItemEventBase>();
                    InGameManager.Instance.MainUI.LooptItemUI(_itembase, false);
                }
                break;
        }
    }
}
