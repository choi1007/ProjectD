using System.Collections.Generic;
using UnityEngine;

public class DialogManager : Singleton<DialogManager>
{
    public bool Open
    {
        get { return DialogStack.Count > 0; }
    }

    public int ShowCount
    {
        get { return DialogStack.Count; }
    }

    private Transform DialogPanel;
    private Stack<DialogBase> DialogStack = new Stack<DialogBase>();

    public void OnWake(Transform _panel) { DialogPanel = _panel; }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Open) RemoveDialog();
            else 
            {
                // AppQuit Dialog.
            }
        }
    }

    public void AddDialog(DialogBase _dialog)
    {
        _dialog.transform.SetParent(DialogPanel, false);
        _dialog.transform.SetAsLastSibling();
        DialogStack.Push(_dialog);
    }

    public void RemoveDialog()
    {
        Destroy(DialogStack.Pop().gameObject);
    }
}
