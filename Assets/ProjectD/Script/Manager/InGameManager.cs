using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : Singleton<InGameManager>
{
    public Camera PlayerCamera { get; private set; }

    public MainUI MainUI { get; private set; }

    public Player Player { get; private set; }
    public Enemy Enemy { get; private set; }

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
        PlayerCamera = Util.GetPrefab<Camera>("Prefabs/InGame/PlayerCamera");

        Player = Util.GetPrefab<Player>("Prefabs/InGame/Character/Player");
        Player.transform.position = new Vector3(4, 0, -6);

        Enemy = Util.GetPrefab<Enemy>("Prefabs/InGame/Character/Enemy");
        Enemy.transform.position = new Vector3(-5, 0, -4);
    }
}
