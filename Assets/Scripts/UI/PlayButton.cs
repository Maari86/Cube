using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public delegate void ButtonClickEvent();
    public static event ButtonClickEvent OnButtonClick;

    public string sceneName; 

    private void Start()
    {
        
        OnButtonClick += LoadScene;
    }

    public void ButtonClick()
    {
        OnButtonClick?.Invoke();
    }

    private void LoadScene()
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneName);
    }
}
