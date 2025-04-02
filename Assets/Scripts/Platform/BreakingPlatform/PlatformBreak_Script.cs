using System.Collections;
using UnityEngine;
using System;

public class PlatformBreak_Script : MonoBehaviour
{
    public float breakDelay = 2.5f; // Time before breaking
    public float respawnTime = 10f; // Time before the platform reappears

    private bool isBreaking = false;
    private Rigidbody2D rb;
    private Collider2D col;
    private SpriteRenderer sr;

    private Vector3 initialPosition; // Store the original position

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();

        initialPosition = transform.position; // Save initial position
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
        transform.position = initialPosition;
        col.enabled = false; // Disable collision
        sr.enabled = false;

        yield return new WaitForSeconds(respawnTime); // Wait before respawning

        // Reactivate platform
        isBreaking = false;
        sr.enabled = true;
        col.enabled = true;
    }
}

