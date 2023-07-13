using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBoxDialogElement : MonoBehaviour
{
    [SerializeField] private GameObject ItemBeforeConfirm;
    [SerializeField] private GameObject ItemAfterConfirm;
    [SerializeField] private Image ItemImage;

    [SerializeField] private Transform ConfrimUILoop;

    private bool m_check = false; // 아이템 확인 누르기 전.
    private bool m_confirm = false;

    private float m_checkTime;
    private float m_checkStayTime = 3f;

    private void Start()
    {
        m_checkTime = 0;
        m_checkStayTime = 3f;
    }

    public void InitElementItem()
    {

    }

    public void Update()
    {
        if (m_confirm) return;
        if (m_check == false) return;
        
        m_checkTime += Time.deltaTime;
        if (m_checkStayTime > m_checkTime)
        {
            m_confirm = true;
            ConfirmItem();
        }
    }

    private void ConfirmItem()
    {
        ItemBeforeConfirm.SetActive(false);
        ItemAfterConfirm.SetActive(true);
    }

    public void OnClickItem()
    {
        if (m_check == false) m_check = true;
        // 아이템 확인 안된건 가져갈 수 없음.
        if (m_confirm == false) return;



    }
}
