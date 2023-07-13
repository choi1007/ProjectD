using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private Transform Main;
    [SerializeField] private Transform Dialog;
    [SerializeField] private RectTransform UICanvas;
    
    public static Transform MainPanel { get { return UIObject.Main; } }
    public static RectTransform Canvas { get { return UIObject.UICanvas; } }

    public static UI UIObject;

    private void Awake()
    {
        UIObject = this;
        DialogManager.Instance.OnWake(Dialog);
    }

}
