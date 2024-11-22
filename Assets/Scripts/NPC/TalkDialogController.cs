using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkDialogController : Singleton<TalkDialogController>
{
    [SerializeField] protected TalkDialogStatus status;

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponent(ref status);
    }
    #endregion

    public virtual void EnableDialog()
    {
        //if (choice.choice1 == "") return;
        //status.ChangeTextInteract(choice);
        gameObject.SetActive(true);
    }

    public virtual void DisableDialog()
    {
        gameObject.SetActive(false);
    }
}
