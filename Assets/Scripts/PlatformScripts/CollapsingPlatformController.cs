using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsingPlatformController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float timeToDrop = 3f;
    [SerializeField] private float timeToDestory = 4f;


    private Vector3 startingPos;
    private Vector3 randomPos;

    private float timer;


    [SerializeField] private float time = 2f;

    public float distance = 0.1f;

    public float delayBetweenShakes = 0.3f;



    private void Awake()
    {
        startingPos = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

 
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            StartCoroutine(Shake());
          Invoke("ColorChange", timeToDrop);
           Destroy(gameObject, timeToDestory);
        }
    }

    // An Coroutine to shake the platform 
    private IEnumerator Shake()
    {
        timer = 0f;

        while (timer < time)
        {
            timeToDrop += Time.deltaTime;
            randomPos = startingPos + (Random.insideUnitSphere * distance);

            transform.position = randomPos;

            if (delayBetweenShakes > 0f)
            {
                yield return new WaitForSeconds(delayBetweenShakes);
            }

            else
            {
                yield return null;
            }
        }

        transform.position = startingPos;
    }



    private void ColorChange()
    {

        GetComponent<Renderer>().material.color = Color.Lerp(Color.red, Color.red, Mathf.PingPong(Time.time, 1));

    }
}

