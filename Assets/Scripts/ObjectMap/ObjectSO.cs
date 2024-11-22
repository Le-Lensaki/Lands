using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Object", menuName = "SO/Object")]
public class ObjectSO : ScriptableObject
{
    public string objectName = "Object";
    public int hpMax = 5;
    public List<Item> dropList;
}
