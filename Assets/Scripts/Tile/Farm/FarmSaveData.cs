using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class FarmSaveData
{
    public Vector3 position;
    public string nameCurrentPlantSO;
    public int dayGrown;
    public int createDay;
    public bool canHarvest;
    public bool canSowSeed;
    public IDGround idGround;
    public int grownPlant;
    public bool isHasSeed;
}
