using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed = 5f; 

    void FixedUpdate()
    {
        transform.Translate(0, 0, -speed * Time.deltaTime);
    }
}
