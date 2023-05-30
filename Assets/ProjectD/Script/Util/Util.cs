using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using MarchingBytes;

public static class Util
{
    public enum GetPrefabType
    {
        Item2D,
        Item3D,
        Dialog,
        Effect,
        Char,
        Map,
    }

    public static Sprite LoadSprite(string atlasName, string spriteName)
    {
        var spriteAtlas = Load<SpriteAtlas>($"Images/{atlasName}");
        if (spriteAtlas != null) return spriteAtlas.GetSprite(spriteName);
        return Load<Sprite>($"Images/{atlasName}/{spriteName}");
    }

    //public static string LoadText(string textKey) => TableManager.Instance.TextExcel.GetLocalizedText(textKey, DataManager.Instance._LanguageType);

    public static T GetPrefab<T>(string _itemName, GetPrefabType type, Vector3 _pos = default, Quaternion _rot = default)
    {
        var pool = EasyObjectPool.instance;
        if (pool != null && pool.GetObjectPoolReturn(_itemName)) return pool.GetObjectFromPool(_itemName, _pos, _rot).GetComponent<T>();
        string path = $"Prefabs/2D/";
        switch (type)
        {
            case GetPrefabType.Item2D: // 2d 아이템.
                path = "Prefabs/2D/";
                break;
            case GetPrefabType.Item3D: // 3d 아이템.
                path = "Prefabs/3D/";
                break;
            case GetPrefabType.Effect:
                path = "Prefabs/Effect/";
                break;
            case GetPrefabType.Dialog:
                path = "Prefabs/Dialog/";
                break;
            case GetPrefabType.Char:
                path = "Prefabs/Character/";
                break;
            case GetPrefabType.Map:
                path = "Prefabs/Map/";
                break;
        }
        path = $"{path}{_itemName}";

        var value = GameObject.Instantiate(Load<GameObject>(path)) as GameObject;
        return value.GetComponent<T>();
    }



    public static void DestroyItem(GameObject _obj)
    {
        var pool = EasyObjectPool.instance;
        var poolobj = _obj.GetComponent<PoolObject>();
        if (pool != null && poolobj != null && pool.GetObjectPoolReturn(poolobj.poolName)) pool.ReturnObjectToPool(_obj);
        else GameObject.Destroy(_obj);
    }

    public static AudioSource GetAudio(string _key)
    {
        return AudioSource.Instantiate(Load<AudioSource>(SoundManager.Instance.FindSoundPath(_key))) as AudioSource;
    }

    static T Load<T>(string _path) where T : UnityEngine.Object
    {
        T r = Resources.Load<T>(_path);
        return r;
    }
}
