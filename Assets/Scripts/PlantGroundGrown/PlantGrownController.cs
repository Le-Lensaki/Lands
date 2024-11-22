using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrownController : LensakiMonoBehaviour, ICanSowSeed
{
    protected PlantGrownStatus status;

    protected override void Awake()
    {
        base.Awake();
        
    }
    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponent(ref status);
    }
    #endregion

    public FarmSaveData GetFarmSaveData()
    {
        FarmSaveData farmSaveData = new FarmSaveData();

        farmSaveData.position = transform.position;
        if (status.CurrentPlantSO != null)
        {
            farmSaveData.nameCurrentPlantSO = status.CurrentPlantSO.name;
        }
        farmSaveData.dayGrown = status.DayGrown;
        farmSaveData.createDay = status.CreateDay;
        farmSaveData.canHarvest= status.CanHarvest;
        farmSaveData.canSowSeed= status.CanSowSeed;
        farmSaveData.idGround = status.Ground.CurrentIDGround;
        farmSaveData.grownPlant = status.Plant.GrownPlant;
        farmSaveData.isHasSeed = status.Plant.IsHasSeed;
        return farmSaveData;
    }
    
    public void SetFarmSaveData(FarmSaveData farmSaveData)
    {
        transform.position = farmSaveData.position;
        status.LoadPlantStatus(farmSaveData);
    }

    public virtual bool Harvest()
    {
        if (!status.CanHarvest) return false;

        status.Harvest();
        return true;
    }
    
    public bool SowSeed(PlantSO plantSO)
    {
        if (!status.SetPLantSO(plantSO)) return false;

        if (status.Ground.CurrentIDGround == IDGround.NoSeedIsSprayed) status.Ground.ChangeGround(IDGround.HasSeedIsSprayed);
        if (status.Ground.CurrentIDGround == IDGround.NoSeed) status.Ground.ChangeGround(IDGround.HasSeedNoSprayed);
        
        status.SowSeed();
        return true;
    }

    public virtual void Spray()
    {
        if(status.Ground.CurrentIDGround == IDGround.HasSeedNoSprayed) status.Ground.ChangeGround(IDGround.HasSeedIsSprayed);

        if (status.Ground.CurrentIDGround == IDGround.NoSeed) status.Ground.ChangeGround(IDGround.NoSeedIsSprayed);
    }

    public bool CanSowSeed()
    {
        return status.CanSowSeed;
    }
}
