using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsyncLoader : Singleton<AsyncLoader>
{
    [SerializeField] protected GameObject startMenu;
    [SerializeField] protected GameObject loadingScreen;


    [SerializeField] protected Slider loadingSlider;
    [SerializeField] protected Animator transitionAnim;
    public void LoadMap(string mapToLoad)
    {
        
        if(startMenu != null)
        {
            startMenu.SetActive(false);
        }    
        loadingScreen.SetActive(true);
        StartCoroutine(LoadMapAsync(mapToLoad));

    }
    

    IEnumerator LoadMapAsync(string mapToLoad)
    {

        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(mapToLoad);
        loadOperation.allowSceneActivation = false;
        Task loadFileTask = SaveManager.Instance.LoadFileAsync();

        while (!loadOperation.isDone)
        {
            float progressValue = loadFileTask.IsCompleted ? Mathf.Clamp01(loadOperation.progress / 0.9f) : Mathf.Min(loadOperation.progress, 0.9f);

            loadingSlider.value = progressValue;


            if (loadingSlider.value >= 0.9f && loadFileTask.IsCompleted)
            {
                if ( loadingSlider.value == 1)
                {
                    transitionAnim.SetTrigger("End");
                    yield return new WaitForSeconds(1);

                    loadOperation.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }
   
}
