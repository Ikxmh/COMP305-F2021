using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformControls : MonoBehaviour
{
    public GameObject waypointObj;
     public float moveSpeed = 5;
    //[SerializeField] private Vector2 waypoint;
    //[SerializeField] private Vector2 waypoint2;



    public List<Transform> waypoints;
   // private Vector2 currentTarget;
    private int currentTargetIndex = 0;

    // Start is called before the first frame update
    void Awake()
    {
        waypoints = new List<Transform>();
        foreach (Transform t in transform.parent.GetChild(1))
        {
            waypoints.Add(t);
        }
        if (waypoints.Count > 0)
        {
            transform.position = waypoints[0].position;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waypoints.Count > 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentTargetIndex].position, Time.deltaTime * moveSpeed);

            if (Vector2.Distance(transform.position, waypoints[currentTargetIndex].position) < 0.01f)
            {
                // close enough
                //currentTarget = waypoint2;

                currentTargetIndex = (currentTargetIndex + 1) % waypoints.Count;
            }
        }
    }

    public void AddNewWayPoints()
    {
        GameObject goObj = Instantiate(waypointObj, Vector2.zero, Quaternion.identity);
        goObj.transform.SetParent(transform.parent.GetChild(1));
        goObj.name = "Waypoint " + waypoints.Count;
        waypoints.Add(goObj.transform);
    }

    public void RemoveWaypoint(int index)
    {
        waypoints.RemoveAt(index);
        // waypoints.TrimExcess();
        DestroyImmediate(transform.parent.GetChild(1).GetChild(index).gameObject);
    }

    public void ClearWaypoints()
    {
        for (int i = 0; i < waypoints.Count; i++)
        {
            DestroyImmediate(waypoints[i].gameObject);
        } 


        waypoints.Clear();

    }
}
