using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class SaveManager : Singleton<SaveManager>
{
    public const string SAVE_1 = "Save_1";
    public const string SAVE_1_2 = "Save_1_2";
    public const string SAVE_1_3 = "Save_1_3";
    public const string SAVE_1_4 = "Save_1_4";
    public const string SAVE_1_5 = "Save_1_5";

    public const string SAVE_2 = "Save_2";
    public const string SAVE_2_2 = "Save_2_2";
    public const string SAVE_2_3 = "Save_2_3";
    public const string SAVE_2_4 = "Save_2_4";
    public const string SAVE_2_5 = "Save_2_5";

    [SerializeField] protected string jsonString1 = "";
    [SerializeField] protected string jsonString1_2 = "";
    [SerializeField] protected string jsonString1_3 = "";
    [SerializeField] protected string jsonString1_4 = "";
    [SerializeField] protected string jsonString1_5 = "";

    [SerializeField] protected string jsonString2 = "";
    [SerializeField] protected string jsonString2_2 = "";
    [SerializeField] protected string jsonString2_3 = "";
    [SerializeField] protected string jsonString2_4 = "";
    [SerializeField] protected string jsonString2_5 = "";

    [SerializeField] protected SaveData saveData1 = new SaveData();
    public SaveData SaveData1 => saveData1;
    [SerializeField] protected SaveData saveData2 = new SaveData();
    public SaveData SaveData2 => saveData2;

    [SerializeField] protected bool isLoad;
    public bool IsLoad => isLoad;

    [SerializeField] protected bool isLoadSave1;
    public bool IsLoadSave1 => isLoadSave1;

    [SerializeField] protected bool isLoadSave2;
    public bool IsLoadSave2 => isLoadSave2;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
    }


    public async Task LoadFileAsync()
    {
        if (isLoad) return;
        await LoadGameAsync1();
        await LoadGameAsync2();
        isLoad = true;
    }

    public virtual void SaveGame1()
    {
        CreateFileSaveData1();
        string newJsonString = JsonUtility.ToJson(saveData1);
        int partLength = newJsonString.Length / 5;

        jsonString1 = newJsonString.Substring(0, partLength);
        jsonString1_2 = newJsonString.Substring(partLength, partLength);
        jsonString1_3 = newJsonString.Substring(partLength * 2, partLength);
        jsonString1_4 = newJsonString.Substring(partLength * 3, partLength);
        jsonString1_5 = newJsonString.Substring(partLength * 4);
        AsyncLoaderSave.Instance.SaveGame(SAVE_1, SAVE_1_2, SAVE_1_3, SAVE_1_4, SAVE_1_5, jsonString1, jsonString1_2, jsonString1_3, jsonString1_4, jsonString1_5);
    }
    public virtual void SaveGame2()
    {
        CreateFileSaveData2();
        string newJsonString = JsonUtility.ToJson(saveData2);
        int partLength = newJsonString.Length / 5;

        jsonString2 = newJsonString.Substring(0, partLength);
        jsonString2_2 = newJsonString.Substring(partLength, partLength);
        jsonString2_3 = newJsonString.Substring(partLength * 2, partLength);
        jsonString2_4 = newJsonString.Substring(partLength * 3, partLength);
        jsonString2_5 = newJsonString.Substring(partLength * 4);
        AsyncLoaderSave.Instance.SaveGame(SAVE_2, SAVE_2_2, SAVE_2_3, SAVE_2_4, SAVE_2_5, jsonString2, jsonString2_2, jsonString2_3, jsonString2_4, jsonString2_5);

    }

    private async Task LoadGameAsync1()
    {
        await LoadDataPartAsync1();

        string newJsonString = jsonString1 + jsonString1_2 + jsonString1_3 + jsonString1_4 + jsonString1_5;

        this.saveData1 = JsonUtility.FromJson<SaveData>(newJsonString);
    }

    private async Task LoadDataPartAsync1()
    {
        jsonString1 = await SaveSystem.GetStringAsync(SaveManager.SAVE_1);
        jsonString1_2 = await SaveSystem.GetStringAsync(SaveManager.SAVE_1_2);
        jsonString1_3 = await SaveSystem.GetStringAsync(SaveManager.SAVE_1_3);
        jsonString1_4 = await SaveSystem.GetStringAsync(SaveManager.SAVE_1_4);
        jsonString1_5 = await SaveSystem.GetStringAsync(SaveManager.SAVE_1_5);
    }


    private async Task LoadGameAsync2()
    {
        await LoadDataPartAsync2();

        string newJsonString = jsonString2 + jsonString2_2 + jsonString2_3 + jsonString2_4 + jsonString2_5;

        this.saveData2 = JsonUtility.FromJson<SaveData>(newJsonString);
    }

    private async Task LoadDataPartAsync2()
    {
        jsonString2 = await SaveSystem.GetStringAsync(SaveManager.SAVE_2);
        jsonString2_2 = await SaveSystem.GetStringAsync(SaveManager.SAVE_2_2);
        jsonString2_3 = await SaveSystem.GetStringAsync(SaveManager.SAVE_2_3);
        jsonString2_4 = await SaveSystem.GetStringAsync(SaveManager.SAVE_2_4);
        jsonString2_5 = await SaveSystem.GetStringAsync(SaveManager.SAVE_2_5);
    }

    public virtual void CreateFileSaveData1()
    {
        saveData1.posPlayer = new PositionPlayer { positionPlayer = PlayerController.Instance.transform.position };
        saveData1.currentHurryStat = PlayerController.Instance.GetCurrentHurryStat();
        saveData1.maxHurryStat = PlayerController.Instance.GetMaxHurryStat();
        saveData1.money = PlayerController.Instance.GetMoney();
        saveData1.currentQuest = PlayerController.Instance.GetCurrentQuest();
        saveData1.allVolume = AudioManager.Instance.VolumeSetting.GetALLVolume();
        saveData1.musicVolume = AudioManager.Instance.VolumeSetting.GetMusicVolume();
        saveData1.sfxVolume = AudioManager.Instance.VolumeSetting.GetSFXVolume();
        saveData1.timeSave = DateTime.Now.ToString("HH:mm dd/MM/yyyy");
        saveData1.inventoryItems = InventoryController.Instance.GetCurentInventory();
        saveData1.mapData = MapManager.Instance.SaveTilemap();
        saveData1.farmSaveData = SpawnerManager.Instance.GetSpawner<PlantGrownSpawner>().CreateListFarmSaveData();
        saveData1.furnitureSaveData = ManagerFurnitureProduct.Instance.CreateListFurnitureSave();
        saveData1.currnentWorldTime = WorldTime.Instance.GetWorldTime();
    }
    public virtual void CreateFileSaveData2()
    {
        saveData2.posPlayer = new PositionPlayer { positionPlayer = PlayerController.Instance.transform.position };
        saveData2.currentHurryStat = PlayerController.Instance.GetCurrentHurryStat();
        saveData2.maxHurryStat = PlayerController.Instance.GetMaxHurryStat();
        saveData2.money = PlayerController.Instance.GetMoney();
        saveData2.allVolume = AudioManager.Instance.VolumeSetting.GetALLVolume();
        saveData2.musicVolume = AudioManager.Instance.VolumeSetting.GetMusicVolume();
        saveData2.sfxVolume = AudioManager.Instance.VolumeSetting.GetSFXVolume();
        saveData2.timeSave = DateTime.Now.ToString("HH:mm dd/MM/yyyy");
        saveData2.inventoryItems = InventoryController.Instance.GetCurentInventory();
        saveData2.mapData = MapManager.Instance.SaveTilemap();
        saveData2.farmSaveData = SpawnerManager.Instance.GetSpawner<PlantGrownSpawner>().CreateListFarmSaveData();
        saveData2.furnitureSaveData = ManagerFurnitureProduct.Instance.CreateListFurnitureSave();
    }

    public virtual void LoadSave1()
    {
        isLoadSave1 = true;
    }
    public virtual void LoadSave2()
    {
        isLoadSave2 = true;
    }


    public virtual bool LoadSaveData()
    {
        if (isLoadSave1)
        {
            LoadSaveData1();
            return true;
        }
        if (isLoadSave2)
        {
            LoadSaveData2();
            return true;
        }
        return false;
    }    

    protected virtual void LoadSaveData1()
    {
        PlayerController.Instance.SetStatusPlayer(saveData1.posPlayer.positionPlayer, saveData1.currentHurryStat, saveData1.maxHurryStat, saveData1.money,saveData1.currentQuest);
        AudioManager.Instance.LoadSaveVolume(saveData1.allVolume, saveData1.musicVolume, saveData1.sfxVolume);
        InventoryController.Instance.LoadInventory(saveData1.inventoryItems);
        MapManager.Instance.LoadTilemapFromJson(saveData1.mapData);
        SpawnerManager.Instance.GetSpawner<PlantGrownSpawner>().LoadListFarmSaveData(saveData1.farmSaveData);
        ManagerFurnitureProduct.Instance.SetListFurnitureSave(saveData1.furnitureSaveData);
        WorldTime.Instance.SetWorldTime(saveData1.currnentWorldTime);
        isLoadSave1 = false;
    }
   

    protected virtual void LoadSaveData2()
    {
        PlayerController.Instance.SetStatusPlayer(saveData2.posPlayer.positionPlayer, saveData2.currentHurryStat, saveData2.maxHurryStat, saveData2.money,saveData2.currentQuest);
        AudioManager.Instance.LoadSaveVolume(saveData2.allVolume, saveData2.musicVolume, saveData2.sfxVolume);
        InventoryController.Instance.LoadInventory(saveData2.inventoryItems);
        MapManager.Instance.LoadTilemapFromJson(saveData2.mapData);
        SpawnerManager.Instance.GetSpawner<PlantGrownSpawner>().LoadListFarmSaveData(saveData2.farmSaveData);
        ManagerFurnitureProduct.Instance.SetListFurnitureSave(saveData2.furnitureSaveData);
        WorldTime.Instance.SetWorldTime(saveData2.currnentWorldTime);
        isLoadSave2 = false;
    }
}
