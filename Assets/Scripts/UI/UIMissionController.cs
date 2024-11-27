using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMissionController : Singleton<UIMissionController>
{
    [SerializeField] protected TMP_Text titleQuest;
    [SerializeField] protected TMP_Text descriptionQuest;
    [SerializeField] protected TMP_Text textGoal;
    [SerializeField] protected TMP_Text coinReward;


    protected override void Start()
    {
        base.Start();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTitleQuest();
        this.LoadDescriptionQuest();
        this.LoadTextGoal();
        this.LoadCoinReward();
    }
    #region LoadComponents
    protected virtual void LoadTitleQuest()
    {
        if (titleQuest != null) return;

        titleQuest = transform.GetChild(0).Find("TitleQuest").GetComponent<TMP_Text>();
        Debug.Log(transform.name + ": LoadTitleQuest", gameObject);
    }

    protected virtual void LoadDescriptionQuest()
    {
        if (descriptionQuest != null) return;

        descriptionQuest = transform.GetChild(0).Find("DescriptionQuest").GetComponent<TMP_Text>();
        Debug.Log(transform.name + ": LoadDescriptionQuest", gameObject);
    }

    protected virtual void LoadTextGoal()
    {
        if (textGoal != null) return;

        textGoal = transform.GetChild(0).Find("TextGoal").GetComponent<TMP_Text>();
        Debug.Log(transform.name + ": LoadTextGoal", gameObject);
    }
    protected virtual void LoadCoinReward()
    {
        if (coinReward != null) return;

        coinReward = transform.GetChild(0).Find("CoinReward").GetComponent<TMP_Text>();
        Debug.Log(transform.name + ": LoadCoinReward", gameObject);
    }
#endregion

    public virtual void Initialize(QuestStatus questStatus)
    {
        titleQuest.text = questStatus.quest.titleQuest;
        descriptionQuest.text = questStatus.quest.discriptionQuest;
        textGoal.text = questStatus.GetStepGoal().nameStepGoal;
        coinReward.text = questStatus.quest.rewards[0].amount.ToString();

        
    }

    public virtual void Clear()
    {
        titleQuest.text = "";
        descriptionQuest.text = "";
        textGoal.text = "";
        coinReward.text = "";
    
    }    
}
