using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoxLootUI : MonoBehaviour
{
    private Camera PlayerCamera;
    private ItemEventBase m_itemBoxObject;
    private RectTransform ItemElement;
    private RectTransform m_uiCanvas;

    private void Awake()
    {
        m_uiCanvas = UI.Canvas;
        PlayerCamera = InGameManager.Instance.PlayerCamera;
        ItemElement = GetComponent<RectTransform>();
    }

    public void InitItemData(ItemEventBase _item)
    {
        m_itemBoxObject = _item;
    }

    private void LateUpdate()
    {
        if (gameObject.activeSelf == false) return;

        var _viewPort = PlayerCamera.WorldToViewportPoint(m_itemBoxObject.transform.position);
        var _worldToScreen = new Vector2(_viewPort.x * m_uiCanvas.sizeDelta.x - m_uiCanvas.sizeDelta.x * 0.5f, 
            _viewPort.y * m_uiCanvas.sizeDelta.y - m_uiCanvas.sizeDelta.y * 0.5f);
        ItemElement.anchoredPosition = _worldToScreen;
    }

    public void OnClickItemloot()
    {
        ItemBoxDialog.DoModal(null);
    }
}
