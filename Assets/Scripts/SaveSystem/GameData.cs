using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData
{

    public Vector2 playerPosition { get; set; }
    public Vector2 playerVelocity { get; set; }

    public Dictionary<string, Vector2> fallingPlatformPositions = new Dictionary<string, Vector2>();
    public Dictionary<string, bool> fallingPlatformStates = new Dictionary<string, bool>();
    public Dictionary<string, Vector3> movingPlatformPositions = new Dictionary<string, Vector3>();
    public Dictionary<string, int> currentWaypointIndices = new Dictionary<string, int>();



    public GameData()
    {

    }
}
