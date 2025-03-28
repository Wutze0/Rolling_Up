using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{

    public Transform waypointParent;
    public GameObject platform;
    private float moveSpeed = 2f;
    private float waitTime = 2f;
    private bool loopWaypoints = true;

    private Transform[] waypoints;
    private Transform target;
    private int currentWaypointIndex = 0;
    private bool isWaiting;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        waypoints = new Transform[waypointParent.childCount];

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
            return;
        }
        MoveToWaypoint();
    }

    void MoveToWaypoint()
    {
        target = waypoints[currentWaypointIndex];

        platform.transform.position = Vector2.MoveTowards(platform.transform.position, target.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(platform.transform.position, target.position) < 0.1f)
        {
            StartCoroutine(WaitAtWaypoint());
        }
    }

    IEnumerator WaitAtWaypoint()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);

        currentWaypointIndex = loopWaypoints ? (currentWaypointIndex + 1) % waypoints.Length : Mathf.Min(currentWaypointIndex + 1, waypoints.Length - 1);

        isWaiting = false;
    }

    



}
