using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    public GameObject prefab;
    public Animator animator;
    public AudioManager audioManager;
    public float delayTime = 2f; 

    private bool collided = false; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") && !collided)
        {
            collided = true; // Set the flag to true to prevent multiple collisions

            // Play death animation
            if (animator != null)
            {
                animator.SetTrigger("Death");
            }

            StopMovementScript();

            // Quit the game after a delay
            StartCoroutine(QuitGameAfterDelay());
        }
    }

    private void StopMovementScript()
    {
        Debug.Log("stop movement");
        audioManager.objectSpawner.isSpawnEnabled = false;
        MovingObject[] movingObjects = FindObjectsOfType<MovingObject>(); // Find all instances of MovingObject script
        foreach (MovingObject movingObject in movingObjects)
        {
            if ((movingObject.gameObject.CompareTag("Cubes") || movingObject.gameObject.CompareTag("Obstacle")) && movingObject.gameObject != prefab)
            {
                movingObject.enabled = false; // Disable the MovingObject script
            }
        }
    }

    private IEnumerator QuitGameAfterDelay()
    {
        yield return new WaitForSeconds(delayTime);
        audioManager.EnableUIImage();
        Time.timeScale = 0f;
        //SceneManager.LoadScene("Loading");
    }
}
