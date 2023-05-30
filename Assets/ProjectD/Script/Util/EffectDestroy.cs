using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MarchingBytes;

public class EffectDestroy : MonoBehaviour
{
    [SerializeField] private float LifeTime;

    private void OnEnable()
    {
        StartCoroutine(TimeLoop());
    }

    private IEnumerator TimeLoop()
    {
        yield return WaitSecondPool.Get(LifeTime);
        EasyObjectPool.instance.ReturnObjectToPool(this.gameObject);
    }
}
