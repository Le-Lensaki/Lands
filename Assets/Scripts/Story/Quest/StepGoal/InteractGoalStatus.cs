using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class InteractGoalStatus : StepGoalStatus
{
    [SerializeField] public InteractGoal interactGoal;
    public virtual bool IsReached()
    {
        return isCompletedStepGoal;
    }

    public void Interact()
    {
        isCompletedStepGoal = true;
    }
}
