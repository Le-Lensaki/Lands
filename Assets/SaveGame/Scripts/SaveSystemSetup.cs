using UnityEngine;
using System.Collections;

public class SaveSystemSetup : MonoBehaviour {

	[SerializeField] private string fileName = "Profile.bin"; // file to save with the specified resolution
    [SerializeField] private bool dontDestroyOnLoad; // the object will move from one scene to another (you only need to add it once)

    void Awake()
	{
        SaveSystem.Initialize(fileName);
        if (dontDestroyOnLoad) DontDestroyOnLoad(transform.gameObject);

        //z();
    }
    //async void z()
    //{
    //    await SaveSystem.InitializeAsync(fileName);

    //    if (dontDestroyOnLoad)
    //    {
    //        DontDestroyOnLoad(transform.gameObject);
    //    }
    //}

    // if the object is present in all game scenes, auto save before exiting
    // on some platforms there may not be an exit function, see the Unity help
    void OnApplicationQuit()
	{
		//SaveSystem.SaveToDiskAsync();
	}
}
