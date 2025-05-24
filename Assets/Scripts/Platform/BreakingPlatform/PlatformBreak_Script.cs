using System.Collections;
using UnityEngine;

public class PlatformBreak_Script : MonoBehaviour, IDataPersistence
{
    public float breakDelay = 2.5f; // Time before breaking
    public float respawnTime = 10f; // Time before the platform reappears

    private bool isBreaking = false;
    private Rigidbody2D rb;
    private Collider2D col;
    private SpriteRenderer sr;

    private string platformID;


    private Vector3 initialPosition; // Store the original position

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();

        initialPosition = transform.position;

        platformID = GenerateIDFromPosition(transform.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isBreaking && collision.gameObject.CompareTag("Player"))
        {
            isBreaking = true;
            StartCoroutine(BreakAndRespawn());
        }
    }

    IEnumerator BreakAndRespawn()
    {
        yield return new WaitForSeconds(breakDelay);

        rb.bodyType = RigidbodyType2D.Dynamic; // Make it fall
        yield return new WaitForSeconds(2f);

        // Hide platform and reset position
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0;
        rb.rotation = 0;
        transform.position = initialPosition;
        col.enabled = false; // Disable collision
        sr.enabled = false;

        yield return new WaitForSeconds(respawnTime); // Wait before respawning

        // Reactivate platform
        isBreaking = false;
        sr.enabled = true;
        col.enabled = true;
    }

    private string GenerateIDFromPosition(Vector3 pos)
    {
        return $"BreakingPlatform_{pos.x}_{pos.y}_{pos.z}";
    }

    public void SaveData(GameData data) //Maybe find a way, so that only platforms that were falling are saved.
    {

        data.fallingPlatformPositions[platformID] = rb.position;
        data.fallingPlatformStates[platformID] = isBreaking;



    }
    public void LoadData(GameData data)
    {
        if (data.fallingPlatformPositions.ContainsKey(platformID))
        {
            rb.position = data.fallingPlatformPositions[platformID];
        }

        if (data.fallingPlatformStates.ContainsKey(platformID))
        {
            isBreaking = data.fallingPlatformStates[platformID];

            if (isBreaking)
            {
                // If the platform was falling when the game was saved, continue the fall
                rb.bodyType = RigidbodyType2D.Dynamic;
                StartCoroutine(FinishFallAndRespawn());
            }
        }
    }


    private void ReactivatePlatform()
    {
        isBreaking = false;
        sr.enabled = true;
        col.enabled = true;
    }

    private void ResetPlatform()
    {
        // Hide platform and reset position
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0;
        rb.rotation = 0;
        transform.position = initialPosition;
        col.enabled = false; // Disable collision
        sr.enabled = false;
    }
    private IEnumerator FinishFallAndRespawn()
    {
        yield return new WaitForSeconds(2f); // Time before resetting platform
        ResetPlatform();
        yield return new WaitForSeconds(respawnTime); // Time before respawning
        ReactivatePlatform();
    }
}

