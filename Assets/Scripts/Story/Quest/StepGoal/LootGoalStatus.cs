using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class LootGoalStatus 
{
    [SerializeField] public LootGoal lootGoal;
    [SerializeField] public int currentAmount;
    [SerializeField] public bool isCompletedLootGoal;

    public virtual void UpdateCurrentAmount()
    {
        if (currentAmount < lootGoal.requiredAmount) currentAmount++;
        IsReached();
    }

    public void IsReached()
    {
        if (currentAmount >= lootGoal.requiredAmount) isCompletedLootGoal = true;
    }
}
