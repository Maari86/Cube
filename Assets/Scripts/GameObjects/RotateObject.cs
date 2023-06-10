using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 10f;

    void FixedUpdate()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
