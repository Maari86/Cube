using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float destroyTime = 5f; // Time in seconds after which the GameObject should be destroyed

    private void Start()
    {
        Invoke("DestroyGameObject", destroyTime);
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
