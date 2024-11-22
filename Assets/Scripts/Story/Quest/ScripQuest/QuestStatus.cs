using Assets.Scripts.Item.IDItem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class QuestStatus 
{
    [SerializeField] public Quest quest;
    [SerializeField] public int currentStep;
    [SerializeField] public bool isAccept;
    [SerializeField] protected bool isCompletedQuest;


    public bool IsCompletedQuest => isCompletedQuest;
    public bool isCompleted()
    {
        if (isAccept && currentStep >= quest.stepGoalList.Count)
        {
            isAccept = false;
            isCompletedQuest = true;
        }
        else
        {
            isCompletedQuest = false;
        }
        return isCompletedQuest;
        //if (lootGoal.IsReached()) ;
    }




    public void AcceptQuest()
    {
        isAccept = true;
    }

    public StepGoalStatus GetStepGoal()
    {
        if (currentStep >= quest.stepGoalList.Count) return null;
        return quest.stepGoalList[currentStep];
    }
    public bool UpdateCurrentStep()
    {
        currentStep++;

        return isCompleted();
    }

    public void UpdateLootGoal(IDItem idItem)
    {
        //lootGoal.UpdateCurrentAmountItem(idItem);
        //isCompleted();
    }
    public void UpdateInteractGoal(IDNPC idNPC)
    {
        //interactGoal.InteractNPC(idNPC);
        //isCompleted();
    }
}
