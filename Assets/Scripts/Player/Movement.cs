using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 0.01f;
    private Touch touch;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float newXPosition = transform.position.x + touch.deltaPosition.x * speed;
                newXPosition = Mathf.Clamp(newXPosition, -2.2f, 2.2f); // Clamp the newXPosition between -2 and 2
                transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
            }
        }
    }
}
