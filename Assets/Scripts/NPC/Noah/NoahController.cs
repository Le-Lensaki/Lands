using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoahController : NPCController
{
    [SerializeField] protected NoahStatus status;

    [SerializeField] protected NoahAnimation anim;

    [SerializeField] protected QuestPoint questPoint;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponent(ref status);
        LoadComponent(ref anim);

        this.LoadQuestPoint();
    }

    #region LoadComponents
    protected virtual void LoadQuestPoint()
    {
        if (questPoint != null) return;
        questPoint = transform.GetChild(0).GetComponent<QuestPoint>();

        Debug.Log(transform.name + ": LoadQuestPoint", gameObject);
    }
    #endregion

    //public override void Interact()
    //{
    //    base.Interact();
    //    InteractQuest();
    //}

    public virtual void InteractQuest()
    {
        if(questPoint.IsGiver)
        {
            DialogueController.Instance.Initialize(GetDialogue(PlayerController.Instance.GetIDDialogueAcceptQuest()),this);
            return;
        }
        if(questPoint.IsCompleted)
        {
            DialogueController.Instance.Initialize(GetDialogue(PlayerController.Instance.GetIDDialogueGoalCurrent()), this);
            CompletedStepQuest();
            return;
        }
        TalkNormal();
    }
    public override void CompletedStepQuest()
    {
        base.CompletedStepQuest();
        questPoint.Completed();
        PlayerController.Instance.SetInteractGoal(questPoint.IDNPC);
    }

    public override void TalkNormal()
    {
        DialogueController.Instance.Initialize(listTalkDialogue[0],this);
    }

    public override void TalkQuest()
    {
        InteractQuest();
    }

    public override void AcceptQuest()
    {
        base.AcceptQuest();
        questPoint.AcceptQuest();
        //UpdateCurrentListQuestDialogue();
    }
   
}
