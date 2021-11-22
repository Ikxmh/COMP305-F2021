using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    [SerializeField] private GameObject itemfeedBack;

    private LevelController levelController;

    private void Start()
    {
        levelController = LevelController.Instance;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Play the "pick up" anikmations 
            GameObject.Instantiate(itemfeedBack, this.transform.position, this.transform.rotation);

            // increase player item pickup counter
            levelController.PickedUpItems();

            Destroy(this.gameObject);
        }
    }
}
