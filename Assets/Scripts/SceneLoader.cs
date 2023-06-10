using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Image loadingBar;
    public float delayBeforeLoading = 1f;
    public float fillSpeed = 0.5f;
    public bool isLoadingComplete = false;

    private void Start()
    {
        Time.timeScale = 1f;
        // Find the audio source in the current scene and mute it...... WHY?
        AudioSource audioSource = FindObjectOfType<AudioSource>();
        if (audioSource != null)
        {
            audioSource.mute = true;
        }

        StartCoroutine(LoadGameSceneAsync());
    }

    private System.Collections.IEnumerator LoadGameSceneAsync()
    {
        yield return new WaitForSeconds(delayBeforeLoading);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("MainMenu");
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            float currentFill = loadingBar.fillAmount;
            float targetFill = progress;

            while (currentFill < targetFill)
            {
                currentFill += fillSpeed * Time.deltaTime;
                loadingBar.fillAmount = currentFill;
                yield return null;
            }

            if (asyncOperation.progress >= 0.9f && isLoadingComplete)
            {
                asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
