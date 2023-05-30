using System.Collections.Generic;
using UnityEngine;

public static class WaitSecondPool
{
    static Dictionary<float, WaitForSeconds> _waitSeconds { get; } = new Dictionary<float, WaitForSeconds>();
    public static WaitForEndOfFrame WaitForEndOfFrame { get; } = new WaitForEndOfFrame();
    public static WaitForFixedUpdate WaitForFixedUpdate { get; } = new WaitForFixedUpdate();

    public static void Clear()
    {
        _waitSeconds.Clear();
    }

    public static WaitForSeconds Get(float fTime)
    {
        if (_waitSeconds.TryGetValue(fTime, out var waitForSeconds) == false) _waitSeconds.Add(fTime, waitForSeconds = new WaitForSeconds(fTime));

        return waitForSeconds;
    }
}
