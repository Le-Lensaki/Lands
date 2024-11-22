using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : Singleton<GameManager>
{

    [SerializeField] protected Animator transitionAnim;

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void PlayGame()
    {
        Time.timeScale = 1;
    }

    public void LoadMapNormal(string mapToLoad)
    {
        PlayGame();
        StartCoroutine(LoadMapDefault(mapToLoad));
    }
    IEnumerator LoadMapDefault(string mapToLoad)
    {

        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(mapToLoad);
        loadOperation.allowSceneActivation = false;
        while (loadOperation.progress < 0.9f)
        {
            yield return null; 
        }

        transitionAnim.SetTrigger("End");

        yield return new WaitForSeconds(1);


        loadOperation.allowSceneActivation = true;

        while (!loadOperation.isDone)
        {
            yield return null;
        }
    }
}
