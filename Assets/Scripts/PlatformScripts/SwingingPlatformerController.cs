using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingPlatformerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;

    [SerializeField] private float leftRange;
    [SerializeField] private float rightRange;

    [SerializeField] private bool isMovingClockwise;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();        
    }

    
    private void ChangeDirection()
    {
        if (transform.rotation.z > rightRange)
        {
            isMovingClockwise = false;
        }
        if (transform.rotation.z < leftRange)
        {
            isMovingClockwise = true;
        }
    }


    private void Move()
    {
        ChangeDirection();

        if (isMovingClockwise)
        {
            rb.angularVelocity = speed;
        }    

        if (!isMovingClockwise)
        {
            rb.angularVelocity = speed * -1;
        }
    }
}
