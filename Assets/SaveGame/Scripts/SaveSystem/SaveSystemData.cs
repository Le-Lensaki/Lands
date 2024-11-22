using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.Tilemaps;
using System.Threading.Tasks;

[System.Serializable]
public class SaveData {

	public string Key {get;set;}
	public string Value {get;set;}

	public PositionPlayer posPlayer;
	public int money;
	public int currentHurryStat;
	public int maxHurryStat;
	public float allVolume;
	public float sfxVolume;
	public float musicVolume;
	public string timeSave;
	public List<InventoryItem> inventoryItems;
	public MapData mapData;
	public ListFarmSave farmSaveData;
	public ListFurnitureSave furnitureSaveData;
    public double currnentWorldTime;
    public int currentQuest;
	public SaveData() { }

    public SaveData(string key, string value)
    {
        this.Key = key;
        this.Value = value;
    }
}

[System.Serializable]
public class DataState {

	public List<SaveData> items = new List<SaveData>();

	public DataState(){}

	public void AddItem(SaveData item)
	{
		items.Add(item);
	}
}

public class SerializatorBinary {

    public static void SaveBinary(DataState state, string dataPath)
    {
        BinaryFormatter binary = new BinaryFormatter();
        FileStream stream = new FileStream(dataPath, FileMode.Create);


        binary.Serialize(stream, state);
        stream.Close();
    }

    public static DataState LoadBinary(string dataPath)
    {
        BinaryFormatter binary = new BinaryFormatter();
        FileStream stream = new FileStream(dataPath, FileMode.Open);
        DataState state = (DataState)binary.Deserialize(stream);
        stream.Close();
        return state;
    }
    //public static async Task SaveBinaryAsync(DataState state, string dataPath)
    //{
    //	BinaryFormatter binary = new BinaryFormatter();

    //	using (FileStream stream = new FileStream(dataPath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, FileOptions.Asynchronous))
    //	{
    //		await Task.Run(() => binary.Serialize(stream, state)); 
    //	}
    //}


    //public static async Task<DataState> LoadBinaryAsync(string dataPath)
    //{
    //	BinaryFormatter binary = new BinaryFormatter();

    //	using (FileStream stream = new FileStream(dataPath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.Asynchronous))
    //	{
    //		return await Task.Run(() => (DataState)binary.Deserialize(stream));
    //	}
    //}
}

