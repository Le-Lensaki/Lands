using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Dialogue", menuName = "SO/Dialogue/Dialogue")]
public class Dialogue : ScriptableObject
{
    [SerializeField] public IDDialogue idDialogue;
    [SerializeField] public List<Content> content;

}



public enum IDDialogue
{
    NoDialogueQuest = 0,

    GiveTool = 1,
    Congratulations = 2,
    Hello = 3,
    MeetAgain = 4,
    TalkNormalNoah = 5,
    CreateBed = 6,
    CreateCompleted = 7,
    Congratulations2 = 8,
    Farm = 9,
    Congratulations3 = 10,

}

public class IDDialogueParser
{
    public static IDDialogue FromString(string idDialogue)
    {
        try
        {
            return (IDDialogue)System.Enum.Parse(typeof(IDDialogue), idDialogue);
        }
        catch (ArgumentException e)
        {
            Debug.LogError(e.ToString());
            return IDDialogue.NoDialogueQuest;
        }
    }
}


