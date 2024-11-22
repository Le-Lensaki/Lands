using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : LensakiMonoBehaviour, ITalk
{
    [SerializeField] protected HighLightTalkController highLightTalk;

    [SerializeField] protected List<Dialogue> listDialogue;
    [SerializeField] protected List<Dialogue> listTalkDialogue;

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHighLightTalk();
    }

    protected virtual void LoadHighLightTalk()
    {
        if (highLightTalk != null) return;

        highLightTalk = transform.GetComponentInChildren<HighLightTalkController>();
        highLightTalk.gameObject.SetActive(false);
        Debug.Log(transform.name + " : LoadHighLightTalk", gameObject);
    }
    #endregion

    public void HighLight()
    {
        //highLightTalk.gameObject.SetActive(true);
        InteractDialogController.Instance.EnableDialog();
    }

    public virtual void AcceptQuest()
    {


    }

    public virtual void CompletedStepQuest()
    {

    }

    public Dialogue GetDialogue(IDDialogue idDialogue)
    {
        foreach (var dialogue in listDialogue)
        {
            if (idDialogue == dialogue.idDialogue) return dialogue;
        }
        return null;
    }

    public virtual void TalkNormal()
    {
       
    }

    public virtual void TalkQuest()
    {
       
    }
}
