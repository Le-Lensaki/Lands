using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanSowSeed
{
    public bool SowSeed(PlantSO plantSO);

    public bool CanSowSeed();
}
