using UnityEngine;

public abstract class DialogBase : MonoBehaviour
{
    public void Show() 
    {
        OnShow();
        DialogManager.Instance.AddDialog(this);
    }

    public void Hide()
    {
        OnHide();
        DialogManager.Instance.RemoveDialog();
    }

    protected virtual void OnShow() { }
    protected virtual void OnHide() { }
}
