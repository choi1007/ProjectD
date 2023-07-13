using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameData;

public class MapItemManager : Singleton<MapItemManager>
{
    public void OnWakeUp() { }


    // 아이템 맵에 만들어서 뿌림.
    // 상자째로 뿌리고 상자안에는 아이템 element가 존재.
    // 확인된건지 아닌지부터 여기서 만들어짐.
    // 비율은 5:5로 생각중.
    public void ItemMapSprinkle()
    {

    }

    /// <summary>
    /// 상자 안에 아이템 리스트 만듬.
    /// </summary>
    /// <returns></returns>
    public List<ItemData> CreateItemBox()
    {
        return null;
    }


    /// <summary>
    /// 아이템 개별 만듬.
    /// </summary>
    /// <returns></returns>

    public ItemData CreateItem()
    {
        return null;
    }
}
