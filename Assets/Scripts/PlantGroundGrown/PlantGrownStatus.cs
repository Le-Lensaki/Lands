using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrownStatus : LensakiMonoBehaviour
{
    [SerializeField] protected List<PlantSO> plants;

    [SerializeField] protected PlantSO currentPlantSO;
    public PlantSO CurrentPlantSO => currentPlantSO;

    [SerializeField] protected Ground ground;
    public Ground Ground => ground;
    [SerializeField] protected Plant plant;
    public Plant Plant => plant;
    [SerializeField] protected int dayGrown;
    public int DayGrown => dayGrown;
    [SerializeField] protected int createDay;
    public int CreateDay => createDay;

    [SerializeField] protected bool canHarvest;
    public bool CanHarvest => canHarvest;

    [SerializeField] protected bool canSowSeed;
    public bool CanSowSeed => canSowSeed;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadListPlantSO();
        this.LoadGround();
        this.LoadPlant();
    }

    #region LoadComponents
    protected virtual void LoadListPlantSO()
    {
        if (this.plants.Count > 0) return;
        string resPath = "Plant/";

        PlantSO[] plantSOs = Resources.LoadAll<PlantSO>(resPath);
        foreach (var item in plantSOs)
        {
            plants.Add(item);
        }
        Debug.Log(transform.name + ": LoadListPlantSO ", gameObject);

    }

    protected virtual void LoadGround()
    {
        if (this.ground != null) return;

        this.ground = transform.GetChild(0).GetChild(0).gameObject.GetComponent<Ground>();
        
        Debug.Log(transform.name + ": LoadGround ", gameObject);
    }

    protected virtual void LoadPlant()
    {
        if (this.plant != null) return;

        this.plant = transform.GetChild(0).GetChild(1).gameObject.GetComponent<Plant>();
        Debug.Log(transform.name + ": LoadPlant ", gameObject);
    }


    #endregion

    public void SowSeed()
    {
        plant.SowSeed();
        this.SetCreateDay();
        canSowSeed = false;
    }

    public virtual void Harvest()
    {
        SpawnerManager.Instance.GetSpawner<ObjectDropItemSpawner>().DropByNameItem("Corn",transform.position);
        ResetFarm();
    }
    protected void ResetFarm()
    {
        currentPlantSO = null;
        ground.ChangeGround(IDGround.NoSeed);
        dayGrown = 0;
        createDay = 0;
        canSowSeed = true;
        canHarvest = false;
        plant.ResetPlant();
    }    


    public void LoadPlantStatus(FarmSaveData farmSaveData)
    {
        this.currentPlantSO = GetPlantSOByName(farmSaveData.nameCurrentPlantSO);
        if(currentPlantSO != null)
        {
            plant.LoadInitialize(currentPlantSO, farmSaveData.grownPlant, farmSaveData.isHasSeed);
            this.dayGrown = farmSaveData.dayGrown;
            this.createDay = farmSaveData.createDay;
            this.canHarvest = farmSaveData.canHarvest;
            this.canSowSeed = farmSaveData.canSowSeed;
            this.ground.ChangeGround(farmSaveData.idGround);
        }
        
    }    

    protected PlantSO GetPlantSOByName(string namePlantSO)
    {
        foreach (var plantSO in plants)
        {
            if (plantSO.plantName == namePlantSO) return plantSO;
        }
        return null;
    }

    

    protected override void OnEnable()
    {
        base.OnEnable();
        canSowSeed = true;
    }
    public virtual void SetCreateDay()
    {
        createDay = WorldTime.Instance.CurrentDay;
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.ResetDayGrown();
    }
    #region ResetValue
    protected virtual void ResetDayGrown()
    {
        dayGrown = 0;
    }
    #endregion




    private void Update()
    {
        this.UpdateDayGrown();
        this.PlantGrown();

    }

    protected void UpdateDayGrown()
    {
        if (!plant.IsHasSeed) return;
        if (dayGrown == (WorldTime.Instance.CurrentDay - createDay)) return;

        dayGrown = WorldTime.Instance.CurrentDay - createDay;
    }

    protected void PlantGrown()
    {
        if (!plant.IsHasSeed) return;
        if ((dayGrown % currentPlantSO.dayGrown) == 0)
        {
            int day = dayGrown / currentPlantSO.dayGrown;
            if (day > 0)
            {
                if(ground.CurrentIDGround != IDGround.NoSeed)
                {
                    ground.ChangeGround(IDGround.NoSeed);
                } 
            }
            if(!plant.ChangeGrownPlant(day)) canHarvest = true;
        }
    }

   

    public virtual bool SetPLantSO(PlantSO plantSO)
    {
        if (currentPlantSO != null) return false;
        this.currentPlantSO = plantSO;
        this.SetSpritesPlant();
        return true;
    }
    protected virtual void SetSpritesPlant()
    {
        this.plant.SetSpritesPlant(currentPlantSO.spriteGrown);
    }
}
