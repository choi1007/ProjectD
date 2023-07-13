using System;
using UnityEngine;

public static class Util
{
    public static T GetPrefab<T>(string _path, Vector3 _pos = default, Quaternion _rot = default)
    {
        var value = GameObject.Instantiate(Load<GameObject>(_path)) as GameObject;
        return value.GetComponent<T>();
    }

    static T Load<T>(string _path) where T : UnityEngine.Object
    {
        T r = Resources.Load<T>(_path);
        return r;
    }

    public static int RandomValue(int _min, int notIncludeMax)
    {
        var _rand = new System.Random(Guid.NewGuid().GetHashCode());
        return _rand.Next(_min, notIncludeMax);
    }
}
