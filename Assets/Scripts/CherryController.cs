using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    [SerializeField] private GameObject itemfeedBack;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Instantiate(itemfeedBack, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
