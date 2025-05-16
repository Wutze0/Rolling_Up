using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour, IDataPersistence
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

    private string platformID;

    private bool dataLoaded = false;

    void Start()
    {
        platformID = GenerateIDFromPosition(transform.position);

        waypoints = new Transform[waypointParent.childCount];
        for (int i = 0; i < waypointParent.childCount; i++)
        {
            waypoints[i] = waypointParent.GetChild(i);
        }

        if (!dataLoaded)
        {
            platform.transform.position = waypoints[0].position;
        }
    }

    void Update()
    {
        if (isWaiting || waypoints == null || waypoints.Length == 0) return;

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

        currentWaypointIndex = loopWaypoints
            ? (currentWaypointIndex + 1) % waypoints.Length
            : Mathf.Min(currentWaypointIndex + 1, waypoints.Length - 1);

        isWaiting = false;
    }

    private string GenerateIDFromPosition(Vector3 pos)
    {
        return $"MovingPlatform_{Mathf.RoundToInt(pos.x)}_{Mathf.RoundToInt(pos.y)}_{Mathf.RoundToInt(pos.z)}";
    }

    public void SaveData(GameData data)
    {
        data.movingPlatformPositions[platformID] = platform.transform.position;
        data.currentWaypointIndices[platformID] = currentWaypointIndex;
    }

    public void LoadData(GameData data)
    {
        if (data.movingPlatformPositions.ContainsKey(platformID) && data.currentWaypointIndices.ContainsKey(platformID))
        {
            platform.transform.position = data.movingPlatformPositions[platformID];
            currentWaypointIndex = Mathf.Clamp(data.currentWaypointIndices[platformID], 0, waypointParent.childCount - 1);
            dataLoaded = true;
        }
    }
}
