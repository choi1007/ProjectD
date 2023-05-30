using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticleEnable : MonoBehaviour
{
    public float Delay;

    private void OnEnable()
    {
        StartCoroutine(ParticleActive());
    }

    private IEnumerator ParticleActive()
    {
        yield return WaitSecondPool.Get(Delay);
        gameObject.SetActive(false);
    }
}
