using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameScene : MonoBehaviour
{
    public MusicManager musicManager;
    public string gameSceneName = "GameWithSoundScene";

    public void GameScene()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
