using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameData;

public class MapItemManager : Singleton<MapItemManager>
{
    public void OnWakeUp() { }


    // ������ �ʿ� ���� �Ѹ�.
    // ����°�� �Ѹ��� ���ھȿ��� ������ element�� ����.
    // Ȯ�εȰ��� �ƴ������� ���⼭ �������.
    // ������ 5:5�� ������.
    public void ItemMapSprinkle()
    {

    }

    /// <summary>
    /// ���� �ȿ� ������ ����Ʈ ����.
    /// </summary>
    /// <returns></returns>
    public List<ItemData> CreateItemBox()
    {
        return null;
    }


    /// <summary>
    /// ������ ���� ����.
    /// </summary>
    /// <returns></returns>

    public ItemData CreateItem()
    {
        return null;
    }
}
