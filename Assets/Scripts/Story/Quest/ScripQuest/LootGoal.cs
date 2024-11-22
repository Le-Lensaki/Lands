using Assets.Scripts.Item.IDItem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "LootGoal", menuName = "SO/StepGoal/LootGoal")]
public class LootGoal : ScriptableObject
{
    [SerializeField] public IDItem idItem;
    [SerializeField] public int requiredAmount;
}
