using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : Singleton<DialogueController>
{

    [SerializeField] protected DialogueStatus status;
    [SerializeField] protected NPCController entityInteract;

    protected override void Awake()
    {
        base.Awake();

    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDialogueStatus();

    }
    #region LoadComponents
    protected virtual void LoadDialogueStatus()
    {
        if (status != null) return;
        status = this.GetComponent<DialogueStatus>();

        Debug.Log(transform.name + ": LoadDialogueStatus", gameObject);
    }
    #endregion

    public void Initialize(Dialogue dialogue,NPCController entityController)
    {
        this.entityInteract = entityController;
        status.SetDialogue(dialogue);
    }

    public void PlayerChoice1()
    {
        entityInteract.AcceptQuest();
        PlayerController.Instance.AcceptQuest();

        status.PushText();
        ChoiceDialogController.Instance.DisableDialog();
    }
    public void PlayerChoice2()
    {
        status.PushText();

        ChoiceDialogController.Instance.DisableDialog();
    }
}
