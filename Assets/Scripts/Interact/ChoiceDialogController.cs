using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceDialogController : Singleton<ChoiceDialogController>
{
    [SerializeField] protected ChoiceDialogStatus status;

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponent(ref status);
    }

    #endregion

    public virtual void EnableDialog(Choice choice)
    {
        if (choice.choice1 == "") return;
        if (choice.choice2 == "") return;
        status.ChangeTextInteract(choice);
        gameObject.SetActive(true);
    }

    public virtual void DisableDialog()
    {
        gameObject.SetActive(false);
        
    }
}
