using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject rightLimit;
    [SerializeField] private GameObject leftLimit;
    [SerializeField] private float speed = 2.0f;
    private int direction = 1;

    [SerializeField] private bool moving;

    public Transform[] children;

    // ensure that the children does not move along with the platform
    private void Awake()
    {
        foreach(Transform child in children)
        {
            child.SetParent(null, true);
        }
    }

    // movement of the platforms
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

        //RaycastHit2D tiltingPlatform = Physics2D.Raycast(titlingPlatformDetection.transform.position, -Vector2.up);
       // Debug.DrawRay(titlingPlatformDetection.transform.position, -Vector2.up * tiltingPlatform.distance, Color.red);


    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            moving = true;
            other.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.collider.transform.SetParent(null);
        }
    }
}
