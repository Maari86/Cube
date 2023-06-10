using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void LoadMainMenuScene()
    {
       // StartCoroutine(LoadSceneWithLoadingScreen("MainMenu"));
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGameScene()
    {
        SceneManager.LoadScene("GameWithSoundScene");
        //StartCoroutine(LoadSceneWithLoadingScreen("GameWithSoundScene"));
    }

    private IEnumerator LoadSceneWithLoadingScreen(string sceneName)
    {
        // Load the loading screen scene
        yield return SceneManager.LoadSceneAsync("Loading");

        // Load the target scene
        yield return SceneManager.LoadSceneAsync(sceneName);

        // Unload the loading screen scene
        SceneManager.UnloadSceneAsync("Loading");
    }
}
