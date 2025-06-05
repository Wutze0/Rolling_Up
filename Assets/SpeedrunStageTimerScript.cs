using UnityEngine;

public class SpeedrunStageTimerScript : MonoBehaviour
{
    public float timeLimit = 10f; // Time in seconds
    private float timer;
    private bool isTiming = false;

    public Transform teleportTarget; 
    public Transform player;         

    void Update()
    {
        if (isTiming)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                Fail(); // If the time runs out, the player gets teleported to the start of the speedrun sequence.
            }
        }
    }

    public void StartTimer()
    {
        timer = timeLimit;
        isTiming = true;
    }

    public void StopTimer()
    {
        isTiming = false;
    }

    void Fail()
    {
        isTiming = false;
        player.position = teleportTarget.position; 
        player.rotation = teleportTarget.rotation;
    }
}
