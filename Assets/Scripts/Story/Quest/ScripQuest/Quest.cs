using Assets.Scripts.Item.IDItem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "Quest", menuName = "SO/Quest")]
public class Quest : ScriptableObject
{
    public string titleQuest;
    public string discriptionQuest;

    public List<StepGoalStatus> stepGoalList = new List<StepGoalStatus>();

    [SerializeField] protected IDDialogue idDialogueAcceptQuest;
    public IDDialogue IDDialogueAcceptQuest => idDialogueAcceptQuest;

    [SerializeField] protected IDNPC idNPCGiveQuest;
    public IDNPC IDNPCGiveQuest => idNPCGiveQuest;

    public List<Reward> rewards;
    

    

}
