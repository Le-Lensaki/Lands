using UnityEngine;
using System.Collections;
using System.IO;
using System.Threading.Tasks;

public static class SaveSystem {
		
	private static string file;
	private static bool loaded;
	private static DataState data;

    public static void Initialize(string fileName) // initialization (used once, after the application starts)
    {
        if (!loaded)
        {
            file = fileName;
			if (File.Exists(GetPath()))
			{
				Load();
			}
			else data = new DataState();
            loaded = true;
        }
    }
    //   public static async Task InitializeAsync(string fileName)
    //{
    //	if (!loaded)
    //	{
    //		file = fileName;
    //		if (File.Exists(GetPath()))
    //		{
    //			Debug.Log("Have");
    //			await LoadAsync();
    //		}
    //		else
    //		{
    //			data = new DataState();
    //		}
    //		loaded = true;
    //	}
    //}


    static string GetPath()
	{
		return Application.persistentDataPath + "/" + file;
	}

    static void Load()
    {
        data = SerializatorBinary.LoadBinary(GetPath());
        Debug.Log("[SaveGame] --> Loading the save file: " + GetPath());
    }
    //   static async Task LoadAsync()
    //{

    //	data = await SerializatorBinary.LoadBinaryAsync(GetPath());
    //	Debug.Log("[SaveGame] --> Loading the save file: " + GetPath());
    //}
    static void ReplaceItem(string name, string item)
    {
        bool j = false;
        for (int i = 0; i < data.items.Count; i++)
        {
            if (string.Compare(name, data.items[i].Key) == 0)
            {
                data.items[i].Value = Crypt(item);
                j = true;
                break;
            }
        }

        if (!j) data.AddItem(new SaveData(name, Crypt(item)));
    }
	static async Task ReplaceItemAsync(string name, string item)
	{
		bool itemReplaced = false;

		for (int i = 0; i < data.items.Count; i++)
		{
			if (string.Compare(name, data.items[i].Key) == 0)
			{
				data.items[i].Value = await CryptAsync(item);
				itemReplaced = true;
				break;
			}
		}

		if (!itemReplaced)
		{
			data.AddItem(new SaveData(name, await CryptAsync(item)));
		}
	}

	

	public static bool HasKey(string name) // check for a key
    {
		if(string.IsNullOrEmpty(name)) return false;

		foreach(SaveData k in data.items)
		{
			if(string.Compare(name, k.Key) == 0)
			{
				return true;
			}
		}

		return false;
	}

	public static void SetVector3(string name, Vector3 val)
	{
		if(string.IsNullOrEmpty(name)) return;
		SetString(name, val.x + "|" + val.y + "|" + val.z);
	}

	public static void SetVector2(string name, Vector2 val)
	{
		if(string.IsNullOrEmpty(name)) return;
		SetString(name, val.x + "|" + val.y);
	}

	public static void SetColor(string name, Color val)
	{
		if(string.IsNullOrEmpty(name)) return;
		SetString(name, val.r + "|" + val.g + "|" + val.b + "|" + val.a);
	}

	public static async void SetBool(string name, bool val) // set the key and value
    {
		if(string.IsNullOrEmpty(name)) return;
		string tmp = string.Empty;
		if(val) tmp = "1"; else tmp = "0";
		await ReplaceItemAsync(name, tmp);
	}

	public static async Task SetBoolAsync(string name, bool val) // set the key and value
	{
		if (string.IsNullOrEmpty(name)) return;
		string tmp = val ? "1" : "0";
		await ReplaceItemAsync(name, tmp);
	}


	public static void SetFloat(string name, float val)
	{
		if(string.IsNullOrEmpty(name)) return;
		 ReplaceItem(name, val.ToString());
	}

	public static void SetInt(string name, int val)
	{
		if(string.IsNullOrEmpty(name)) return;
		 ReplaceItem(name, val.ToString());
	}

	public static async Task SetStringAsync(string name, string val)
	{
		if(string.IsNullOrEmpty(name)) return;
		await ReplaceItemAsync(name, val);
	}

	public static void SetString(string name, string val)
	{
		if (string.IsNullOrEmpty(name)) return;
		ReplaceItem(name, val);
	}

	public static void SaveToDisk() // write data to file
    {

		if (data.items.Count == 0) return;
        SerializatorBinary.SaveBinary(data, GetPath());
        Debug.Log("[SaveGame] --> Save game data: " + GetPath());
    }
 //   public static async Task SaveToDiskAsync() 
	//{
	//	if (data.items.Count == 0) return;

	//	await SerializatorBinary.SaveBinaryAsync(data, GetPath());
	//	Debug.Log("[SaveGame] --> Save game data: " + GetPath());
	//}

	public static Vector3 GetVector3(string name)
	{
		if(string.IsNullOrEmpty(name)) return Vector3.zero;
		return iVector3(name, Vector3.zero);
	}

	public static Vector3 GetVector3(string name, Vector3 defaultValue)
	{
		if(string.IsNullOrEmpty(name)) return defaultValue;
		return iVector3(name, defaultValue);
	}

	static Vector3 iVector3(string name, Vector3 defaultValue)
	{
		Vector3 vector = Vector3.zero;

		for(int i = 0; i < data.items.Count; i++)
		{
			if(string.Compare(name, data.items[i].Key) == 0)
			{
				string[] t = Crypt(data.items[i].Value).Split(new char[]{'|'});
				if(t.Length == 3)
				{
					vector.x = floatParse(t[0]);
					vector.y = floatParse(t[1]);
					vector.z = floatParse(t[2]);
					return vector;
				}
				break;
			}
		}

		return defaultValue;
	}

	public static Vector2 GetVector2(string name)
	{
		if(string.IsNullOrEmpty(name)) return Vector2.zero;
		return iVector2(name, Vector2.zero);
	}

	public static Vector2 GetVector2(string name, Vector2 defaultValue)
	{
		if(string.IsNullOrEmpty(name)) return defaultValue;
		return iVector2(name, defaultValue);
	}

	static Vector2 iVector2(string name, Vector2 defaultValue)
	{
		Vector2 vector = Vector2.zero;

		for(int i = 0; i < data.items.Count; i++)
		{
			if(string.Compare(name, data.items[i].Key) == 0)
			{
				string[] t = Crypt(data.items[i].Value).Split(new char[]{'|'});
				if(t.Length == 2)
				{
					vector.x = floatParse(t[0]);
					vector.y = floatParse(t[1]);
					return vector;
				}
				break;
			}
		}

		return defaultValue;
	}

	public static Color GetColor(string name)
	{
		if(string.IsNullOrEmpty(name)) return Color.white;
		return iColor(name, Color.white);
	}

	public static Color GetColor(string name, Color defaultValue)
	{
		if(string.IsNullOrEmpty(name)) return defaultValue;
		return iColor(name, defaultValue);
	}

	static Color iColor(string name, Color defaultValue)
	{
		Color color = Color.clear;

		for(int i = 0; i < data.items.Count; i++)
		{
			if(string.Compare(name, data.items[i].Key) == 0)
			{
				string[] t = Crypt(data.items[i].Value).Split(new char[]{'|'});
				if(t.Length == 4)
				{
					color.r = floatParse(t[0]);
					color.g = floatParse(t[1]);
					color.b = floatParse(t[2]);
					color.a = floatParse(t[3]);
					return color;
				}
				break;
			}
		}

		return defaultValue;
	}

	public static bool GetBool(string name) // get value by key
    {
		if(string.IsNullOrEmpty(name)) return false;
		return iBool(name, false);
	}

	public static bool GetBool(string name, bool defaultValue) // with the default setting
    {
		if(string.IsNullOrEmpty(name)) return defaultValue;
		return iBool(name, defaultValue);
	}

	static bool iBool(string name, bool defaultValue)
	{
		for(int i = 0; i < data.items.Count; i++)
		{
			if(string.Compare(name, data.items[i].Key) == 0)
			{
				if(string.Compare(Crypt(data.items[i].Value), "1") == 0) return true; else return false;
			}
		}

		return defaultValue;
	}

	public static float GetFloat(string name)
	{
		if(string.IsNullOrEmpty(name)) return 0;
		return iFloat(name, 0);
	}

	public static float GetFloat(string name, float defaultValue)
	{
		if(string.IsNullOrEmpty(name)) return defaultValue;
		return iFloat(name, defaultValue);
	}

	static float iFloat(string name, float defaultValue)
	{
		for(int i = 0; i < data.items.Count; i++)
		{
			if(string.Compare(name, data.items[i].Key) == 0)
			{
				return floatParse(Crypt(data.items[i].Value));
			}
		}

		return defaultValue;
	}

	public static int GetInt(string name)
	{
		if(string.IsNullOrEmpty(name)) return 0;
		return iInt(name, 0);
	}

	public static int GetInt(string name, int defaultValue)
	{
		if(string.IsNullOrEmpty(name)) return defaultValue;
		return iInt(name, defaultValue);
	}

	static int iInt(string name, int defaultValue)
	{
        if (data != null)
        {
            for (int i = 0; i < data.items.Count; i++)
            {
                if (string.Compare(name, data.items[i].Key) == 0)
                {
                    return intParse(Crypt(data.items[i].Value));
                }
            }
        }

		return defaultValue;
	}

	public static string GetString(string name)
	{
		if(string.IsNullOrEmpty(name)) return string.Empty;
		return iString(name, string.Empty);
	}

	public static string GetString(string name, string defaultValue)
	{
		if(string.IsNullOrEmpty(name)) return defaultValue;
		return iString(name, defaultValue);
	}

	static string iString(string name, string defaultValue)
	{
		for(int i = 0; i < data.items.Count; i++)
		{
			if(string.Compare(name, data.items[i].Key) == 0)
			{
				return Crypt(data.items[i].Value);
			}
		}

		return defaultValue;
	}

	public static async Task<string> GetStringAsync(string name)
	{
		if (string.IsNullOrEmpty(name)) return string.Empty;
		return await iStringAsync(name, string.Empty);
	}

	public static async Task<string> GetStringAsync(string name, string defaultValue)
	{
		if (string.IsNullOrEmpty(name)) return defaultValue;
		return await iStringAsync(name, defaultValue);
	}

	static async Task<string> iStringAsync(string name, string defaultValue)
	{
		for (int i = 0; i < data.items.Count; i++)
		{
			if (string.Compare(name, data.items[i].Key) == 0)
			{
				return await CryptAsync(data.items[i].Value);
			}
		}

		return defaultValue;
	}

	static int intParse(string val)
	{
		int value;
		if(int.TryParse(val, out value)) return value;
		return 0;
	}

	static float floatParse(string val)
	{
		float value;
		if(float.TryParse(val, out value)) return value;
		return 0;
	}

	static string Crypt(string text)
	{
		string result = string.Empty;
		foreach(char j in text) result += (char)((int)j ^ 42);
		return result;
	}
	static Task<string> CryptAsync(string text)
	{
		return Task.Run(() =>
		{
			string result = string.Empty;
			foreach (char j in text) result += (char)((int)j ^ 42);
			return result;
		});
	}
}
