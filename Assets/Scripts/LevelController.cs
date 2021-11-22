using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
{
    // Singleton
    private static LevelController _instance;

    public static LevelController Instance
    {
        get
        {
            return _instance;
        }
    }

    // "public" variables 
    [SerializeField] private Text itemUIText;

    // private variables 
    private int totalItemsQty = 0, itemCollectedQty = 0;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        totalItemsQty = GameObject.FindGameObjectsWithTag("Item").Length;
        // Debug.Log("There are " + totalItemsQty + " items in this level.");
        UpdateItemUI();
    }

    private void UpdateItemUI()
    {
        itemUIText.text = itemCollectedQty + " / " + totalItemsQty;
    }

    public void PickedUpItems()
    {
        itemCollectedQty++;
        //Debug.Log("# of the items collected + " + itemCollectedQty);
        UpdateItemUI();
    }

    public void CheckLevelEnd()
    {
        if(itemCollectedQty == totalItemsQty)
        {
            // go to the next level 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
