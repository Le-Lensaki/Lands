using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPoint : LensakiMonoBehaviour
{
    [SerializeField] protected IDNPC idNPC;
    public IDNPC IDNPC => idNPC;
    [SerializeField] protected bool isGiver;
    public bool IsGiver => isGiver;
    [SerializeField] protected bool isCompleted;
    public bool IsCompleted => isCompleted;

    [SerializeField] protected Sprite haveQuest;
    [SerializeField] protected Sprite completedQuest;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadIDNPC();
        this.LoadSpriteHaveQuest();
        this.LoadCompletedQuest();
    }
    #region LoadComponents
    protected void LoadIDNPC()
    {
        if (IDNPC != IDNPC.NoNPC) return;
        if (transform.parent == null) return;
        idNPC = IDNPCParser.FromString(transform.parent.name);
        Debug.Log(transform.name + ": LoadIDNPC", gameObject);
    }

    protected void LoadSpriteHaveQuest()
    {
        if (haveQuest != null) return;
        string resPath = "Emoji/" + "Emoji spritesheet";
        string nameSprite = "Emoji_TagMission";
        Sprite[] sprites = Resources.LoadAll<Sprite>(resPath);
        foreach (var item in sprites)
        {
            if (item.name == nameSprite) this.haveQuest = item;
        }

        Debug.Log(transform.name + ": LoadSpriteHaveQuest" + resPath, gameObject);
    }
    protected void LoadCompletedQuest()
    {
        if (completedQuest != null) return;
        string resPath = "Emoji/" + "Emoji spritesheet";
        string nameSprite = "Emoji_TagMissionCompleted";
        Sprite[] sprites = Resources.LoadAll<Sprite>(resPath);
        foreach (var item in sprites)
        {
            if (item.name == nameSprite) this.completedQuest = item;
        }

        Debug.Log(transform.name + ": LoadCompletedQuest" + resPath, gameObject);
    }
    #endregion


    public QuestPoint CheckQuestPoint(IDNPC id)
    {
        if(id == idNPC) return this;
        else return null;
    }


    public void HaveQuest()
    {
        ResetStatus();
        isGiver = true;

        ChangeTagMissionToHaveQuest();
    }

    protected void ChangeTagMissionToHaveQuest()
    {
        gameObject.SetActive(true);
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = haveQuest;
    }

    public void AcceptQuest()
    {
        ResetStatus();
        HideTagMission();
    }
    protected void HideTagMission()
    {
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = null;
        gameObject.SetActive(false);
    }

    public void CanCompleted()
    {
        ResetStatus();
        isCompleted = true;
        
        ChangeTagMissionToCompletedQuest();
    }
    protected void ChangeTagMissionToCompletedQuest()
    {
        gameObject.SetActive(true);
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = completedQuest;
    }
    public void Completed()
    {
        ResetStatus();
        HideTagMission();
    }

    public void ResetStatus()
    {
        isGiver = false;
        isCompleted = false;
        gameObject.SetActive(false);
    }
}
