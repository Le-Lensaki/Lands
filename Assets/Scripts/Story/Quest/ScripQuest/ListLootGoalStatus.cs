using Assets.Scripts.Item.IDItem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ListLootGoalStatus : StepGoalStatus
{
    [SerializeField] public List<LootGoalStatus> listLootGoalStatus;
    public bool IsCompletedListLootGoal()
    {
        if (listLootGoalStatus.Count == 0)
        {
            return isCompletedStepGoal = true;
        }
        for (int i = 0; i < listLootGoalStatus.Count; i++)
        {
            if (!listLootGoalStatus[i].isCompletedLootGoal)
            {
                return isCompletedStepGoal = false;
            }
        }
        return isCompletedStepGoal = true;
    }

    public void UpdateCurrentAmountItem(IDItem idItem)
    {
        foreach (var goal in listLootGoalStatus)
        {
            if (idItem == goal.lootGoal.idItem) goal.UpdateCurrentAmount();
        }
        IsCompletedListLootGoal();
    }

}
