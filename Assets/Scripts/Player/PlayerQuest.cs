using Assets.Scripts.Item.IDItem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuest : LensakiMonoBehaviour
{
    [SerializeField] protected List<QuestStatus> listQuest;

    [SerializeField] protected int currentQuest;
    [SerializeField] protected List<InteractGoalStatus> listInteractGoalStatus;
    [SerializeField] protected List<ListLootGoalStatus> listLootGoalStatus;
    public int CurrentQuest => currentQuest;



    public void InitializeListQuest()
    {
        listQuest[0].quest.stepGoalList.Add(listLootGoalStatus[0]);
        listQuest[0].quest.stepGoalList.Add(listInteractGoalStatus[0]);

        listQuest[1].quest.stepGoalList.Add(listLootGoalStatus[1]);
        listQuest[1].quest.stepGoalList.Add(listInteractGoalStatus[1]);

        listQuest[2].quest.stepGoalList.Add(listLootGoalStatus[2]);
        listQuest[2].quest.stepGoalList.Add(listInteractGoalStatus[2]);
        StartQuest();
    }    



    public void SetCurrentQuest(int currentQuest)
    {
        this.currentQuest = currentQuest;
    }    


    public virtual void StartQuest()
    {
        QuestStatus currentQuestStatus = GetCurrentQuestStatus();
       
        if (currentQuestStatus == null) return;
        if (!currentQuestStatus.isAccept)
        {
            QuestPoint questPoint = QuestManager.Instance.GetQuestPoint(currentQuestStatus.quest.IDNPCGiveQuest);
            if (questPoint != null)
            {
                questPoint.HaveQuest();
            }
        }
    }
    public virtual QuestStatus GetCurrentQuestStatus()
    {
        if (currentQuest >= listQuest.Count) return null;
        return listQuest[currentQuest];
    }

    public void CheckStepGoal()
    {
        StepGoalStatus stepGoal = GetStepGoal();

        if (stepGoal != null)
        {
            if (stepGoal is InteractGoalStatus interactGoal)
            {
                QuestPoint questPoint = QuestManager.Instance.GetQuestPoint(interactGoal.interactGoal.idNPCInteractGoal);
                if (questPoint != null)
                {
                    questPoint.CanCompleted();
                }
                return;
            }
        }
    }

    public virtual IDDialogue GetIDDialogueAcceptQuest()
    {
        return GetCurrentQuestStatus().quest.IDDialogueAcceptQuest;
    }
    
    public virtual void AcceptQuest()
    {
        listQuest[currentQuest].AcceptQuest();
    }

    public virtual void UpdateCurrentQuest()
    {
        if (GetCurrentQuestStatus().IsCompletedQuest) currentQuest++;
        StartQuest();

    }
    
    public IDDialogue IDDialogueGoalCurrent()
    {
        if (GetStepGoal() is InteractGoalStatus interactGoal)
        { 
            return interactGoal.interactGoal.idDialogueInteractGoal;
        }
        return IDDialogue.NoDialogueQuest;
    }
    public void CheckCompletedStepQuest()
    {
        QuestStatus questCurent = GetCurrentQuestStatus();
        if (questCurent == null) return;
        if (GetStepGoal() == null) return;
        if (!GetStepGoal().isCompletedStepGoal) return;

        if (questCurent.UpdateCurrentStep())
        {
            CompletedQuest();
            UIMissionController.Instance.Clear();
            return;
        }
        CheckStepGoal();
        UIMissionController.Instance.Initialize(questCurent);
    }

    public void CompletedQuest()
    {
        GiveReward();
        UpdateCurrentQuest();      
    }

    public void GiveReward()
    {
        PlayerController.Instance.UpdateMoney(GetCurrentQuestStatus().quest.rewards[0].amount);
    }

    public StepGoalStatus GetStepGoal()
    {
        if(GetCurrentQuestStatus() == null) return null;
        return GetCurrentQuestStatus().GetStepGoal();
    }

    public void UpdateCurrentAmountLootItemGoal(IDItem idItem)
    {
        if (GetStepGoal() is ListLootGoalStatus listLootGoal)
        {
            listLootGoal.UpdateCurrentAmountItem(idItem);
        }
    }

}
