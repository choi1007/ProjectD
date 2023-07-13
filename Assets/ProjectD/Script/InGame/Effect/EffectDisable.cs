using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDisable : MonoBehaviour
{
    [SerializeField] private float DisableTime;
    private float Timer;

    private void OnEnable()
    {
        Timer = 0;
    }

    private void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > DisableTime)
            gameObject.SetActive(false);
    }
}
