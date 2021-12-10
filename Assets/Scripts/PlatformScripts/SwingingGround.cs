using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingGround : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.CompareTag("Player"))
        {
            other.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (gameObject.CompareTag("Player"))
        {
            other.collider.transform.SetParent(null);
        }
    }
}
