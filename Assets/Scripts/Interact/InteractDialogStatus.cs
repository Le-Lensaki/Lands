using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractDialogStatus : LensakiMonoBehaviour
{
    [SerializeField] protected GameObject chosenInteract_1;
    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadGameObjectByName(ref chosenInteract_1, "ButtonIteract");
    }
    
    #endregion

    public virtual void ChangeTextInteract(Choice choice)
    {
        chosenInteract_1.transform.GetChild(0).GetComponent<TMP_Text>().text = choice.choice1;
        

    }
}
