using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TalkDialogStatus : LensakiMonoBehaviour
{
    [SerializeField] protected GameObject chosenTalk_1;
    [SerializeField] protected GameObject chosenTalk_2;

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadGameObjectByName(ref chosenTalk_1, "ButtonTalkQuest");
        LoadGameObjectByName(ref chosenTalk_2, "ButtonTalkNormal");
    }
    #endregion

    public virtual void ChangeTextInteract(Choice choice)
    {
        chosenTalk_1.transform.GetChild(0).GetComponent<TMP_Text>().text = choice.choice1;


    }
}
