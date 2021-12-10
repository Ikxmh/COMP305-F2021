using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingHazards : MonoBehaviour
{
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private GameObject leftLimit;
    [SerializeField] private GameObject rightLimit;
    private int direction = 1;

    [SerializeField] private bool moving;



    // movement of the Skulls
    private void FixedUpdate()
    {
        if (transform.position.x > rightLimit.transform.position.x)
        {
            direction = -1;
        }
        else if (transform.position.x < leftLimit.transform.position.x)
        {
            direction = 1;
        }

        Vector3 movement = Vector3.right * direction * speed * Time.fixedDeltaTime;
        transform.Translate(movement);
    }
}
