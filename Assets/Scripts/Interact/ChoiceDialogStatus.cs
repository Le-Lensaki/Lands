using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChoiceDialogStatus : LensakiMonoBehaviour
{
    [SerializeField] protected GameObject chosenInteract_1;
    [SerializeField] protected GameObject chosenInteract_2;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadChosenInteract_1();
        this.LoadChosenInteract_2();
    }
    #region LoadComponents
    protected virtual void LoadChosenInteract_1()
    {
        if (chosenInteract_1 != null) return;
        chosenInteract_1 = transform.GetChild(0).gameObject;

        Debug.Log(transform.name + ": LoadChosenInteract_1", gameObject);

    }
    protected virtual void LoadChosenInteract_2()
    {
        if (chosenInteract_2 != null) return;
        chosenInteract_2 = transform.GetChild(1).gameObject;

        Debug.Log(transform.name + ": LoadChosenInteract_2", gameObject);

    }
    #endregion

    public virtual void ChangeTextInteract(Choice choice)
    {
        chosenInteract_1.transform.GetChild(0).GetComponent<TMP_Text>().text = choice.choice1;
        chosenInteract_2.transform.GetChild(0).GetComponent<TMP_Text>().text = choice.choice2;
    }    
}
