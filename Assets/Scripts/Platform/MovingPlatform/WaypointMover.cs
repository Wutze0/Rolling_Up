using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{

    public Transform waypointParent;
    public GameObject platform;
    private float moveSpeed = 2f;
    private float waitTime = 2f;
    public bool loopWaypoints = true;

    private Transform[] waypoints;
    private Transform target;
    private int currentWaypointIndex = 0;
    private bool isWaiting;


    
    void Start()
    {
        waypoints = new Transform[waypointParent.childCount];           //Creating an array with the waypoints the platform will move to

        for (int i = 0; i < waypointParent.childCount; i++)
        {
            waypoints[i] = waypointParent.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isWaiting)
        {
            return;                 //If the platform is currently waiting, it should not move to the next waypoint
        }
        MoveToWaypoint();
    }

    void MoveToWaypoint()//Moving the platform to the next waypoint and starting the wait method.
    {
        target = waypoints[currentWaypointIndex];   

        platform.transform.position = Vector2.MoveTowards(platform.transform.position, target.position, moveSpeed * Time.deltaTime);//moves the platform to the position of the next waypoint

        if (Vector2.Distance(platform.transform.position, target.position) < 0.1f)//If close enough, the platform will start waiting
        {
            StartCoroutine(WaitAtWaypoint());
        }
    }

    IEnumerator WaitAtWaypoint()    //Waiting at a Waypoint for x seconds and then selecting the next target position
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);

        currentWaypointIndex = loopWaypoints ? (currentWaypointIndex + 1) % waypoints.Length : Mathf.Min(currentWaypointIndex + 1, waypoints.Length - 1);//when not looping the platform stops at the last waypoint

        isWaiting = false;
    }






}
