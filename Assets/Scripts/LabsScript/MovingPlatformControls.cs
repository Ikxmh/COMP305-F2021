using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformControls : MonoBehaviour
{

    //[SerializeField] private Vector2 waypoint;
    //[SerializeField] private Vector2 waypoint2;

    [SerializeField] List<Vector2> waypoints;
   // private Vector2 currentTarget;
    private int currentTargetIndex;

    // Start is called before the first frame update
    void Start()
    {
        // currentTarget = waypoint;

        currentTargetIndex = 0;
       // currentTarget = waypoints[currentTargetIndex];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentTargetIndex], Time.deltaTime);

        if(Vector2.Distance(transform.position, waypoints[currentTargetIndex]) < 0.01f)
        {
            // close enough
            //currentTarget = waypoint2;


        }
    }
}
