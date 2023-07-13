using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitInGame : MonoBehaviour
{
    private void Awake()
    {
        InGameManager.Instance.OnWake();
    }

    private void Start()
    {
        InGameManager.Instance.InitInGame();
    }

}
