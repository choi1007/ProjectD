using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : Singleton<InGameManager>
{
    public Camera PlayerCamera { get; private set; }

    public MainUI MainUI { get; private set; }

    public void OnWake() { }

    public void InitInGame()
    {
        InitUI();
        InitCamera();
    }

    private void InitUI()
    {
        if (MainUI == null)
        {
            MainUI = Util.GetPrefab<MainUI>("Prefabs/MainUI");
            MainUI.transform.SetParent(UI.MainPanel, false);
            MainUI.InitMainUI();
        }
    }

    private void InitCamera()
    {
        if (PlayerCamera == null) PlayerCamera = Util.GetPrefab<Camera>("Prefabs/InGame/PlayerCamera");

    }
}
