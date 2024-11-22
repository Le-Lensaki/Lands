using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class AsyncLoaderSave : Singleton<AsyncLoaderSave>
{
    [SerializeField] protected GameObject screenSave;
    [SerializeField] protected GameObject loadingScreen;


    [SerializeField] protected Slider loadingSlider;
    public void SaveGame(string SAVE1,string SAVE2,string SAVE3, string SAVE4, string SAVE5, string jsonString1, string jsonString2, string jsonString3, string jsonString4, string jsonString5)
    {
        screenSave.SetActive(false);
        loadingScreen.SetActive(true);

        StartCoroutine(SaveGameAsync(SAVE1, SAVE2, SAVE3, SAVE4, SAVE5, jsonString1, jsonString2, jsonString3, jsonString4, jsonString5));
        
    }

    IEnumerator SaveGameAsync(string SAVE1, string SAVE2, string SAVE3, string SAVE4, string SAVE5, string jsonString1, string jsonString2, string jsonString3, string jsonString4, string jsonString5)
    {

        var progress = new Progress<float>(value => loadingSlider.value = value);


        var saveTask = SaveDataPartAsync(SAVE1, SAVE2, SAVE3, SAVE4, SAVE5, progress, jsonString1, jsonString2, jsonString3, jsonString4, jsonString5);


        while (!saveTask.IsCompleted)
        {
            yield return null;
        }


        screenSave.SetActive(true);
        loadingScreen.SetActive(false);
        AudioManager.Instance.PlaySFX(AudioClipName.save);
    }


    private async Task SaveDataPartAsync(string SAVE1, string SAVE2, string SAVE3, string SAVE4, string SAVE5, IProgress<float> progress, string jsonString1, string jsonString2, string jsonString3, string jsonString4, string jsonString5)
    {
        int totalSteps = 5;

        await SaveSystem.SetStringAsync(SAVE1, jsonString1);
        progress.Report(1f / totalSteps);

        await SaveSystem.SetStringAsync(SAVE2, jsonString2);
        progress.Report(2f / totalSteps);

        await SaveSystem.SetStringAsync(SAVE3, jsonString3);
        progress.Report(3f / totalSteps);

        await SaveSystem.SetStringAsync(SAVE4, jsonString4);
        progress.Report(4f / totalSteps);

        await SaveSystem.SetStringAsync(SAVE5, jsonString5);
        progress.Report(5f / totalSteps); 

        SaveSystem.SaveToDisk();

        progress.Report(1f);
    }
    

}
