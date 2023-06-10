using System.Collections;

using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class PermissionRequest : MonoBehaviour
{
    public SceneLoader sceneLoader;
    private bool questionAsked;
    private void Start()
    {
        questionAsked = false;
#if PLATFORM_ANDROID
        Permission.RequestUserPermission(Permission.ExternalStorageRead);
        questionAsked = true;
        StartCoroutine(MyRoutine());
#endif
    }

    private IEnumerator MyRoutine()
    {
        questionAsked = true;
        if (questionAsked && Permission.HasUserAuthorizedPermission(Permission.ExternalStorageRead))
        {
            questionAsked = false;
            sceneLoader.isLoadingComplete = true;
            //SceneManager.LoadScene(1);
        }
        else if (questionAsked && Permission.HasUserAuthorizedPermission(Permission.ExternalStorageRead))
        {
            questionAsked = false;
            Permission.RequestUserPermission(Permission.ExternalStorageRead);

        }


        yield return new WaitForSeconds(3f);

        StartCoroutine(MyRoutine());
    }
}