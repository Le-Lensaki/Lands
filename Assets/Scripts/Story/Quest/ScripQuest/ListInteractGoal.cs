using Assets.Scripts.Item.IDItem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ListInteractGoal
{
    public List<InteractGoal> interactGoal;

    public bool IsCompleted()
    {
        //if (interactGoal.Count == 0) return true;
        //for (int i = 0; i < interactGoal.Count; i++)
        //{
        //    if (!interactGoal[i].IsReached()) return false;
        //}
        return true;
    }

    public void InteractNPC(IDNPC iDNPC)
    {
        //foreach (var goal in interactGoal)
        //{
        //    if (iDNPC == goal.idNPCInteractGoal) goal.Interact();
        //}
    }
}
