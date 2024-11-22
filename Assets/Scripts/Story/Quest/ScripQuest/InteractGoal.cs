using Assets.Scripts.Item.IDItem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "InteractGoal", menuName = "SO/StepGoal/InteractGoal")]
public class InteractGoal : StepGoal
{
    public IDNPC idNPCInteractGoal;
    public IDDialogue idDialogueInteractGoal;
}
