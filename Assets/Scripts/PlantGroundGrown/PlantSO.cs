using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Object", menuName = "SO/Plant")]
public class PlantSO : ScriptableObject
{
    public string plantName = "Plant";
    public int dayGrown = 3;
    public List<Sprite> spriteGrown;
    public List<Item> dropList;
}
