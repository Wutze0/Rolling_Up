using UnityEngine;

public class PlayerJumpScript : MonoBehaviour
{
    public Rigidbody2D _player;
    private const float jumpHeight = 10f;
    private const KeyCode jumpKey = KeyCode.Space;
    public bool isGrounded; //variable to prevent double jumping / jumping in the air
    private int collidingPlatformsAmount = 0;
    void Update()
    {
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            _player.linearVelocityY = jumpHeight;
            isGrounded = false; 
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{

    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        isGrounded = true;
    //    }

    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        isGrounded = false;
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            collidingPlatformsAmount++;
        }
        if (collidingPlatformsAmount > 0)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            collidingPlatformsAmount--;
        }


        if (collidingPlatformsAmount > 0)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

    }

    //private void OnCollisionStay(Collision collisionInfo)
    //{
    //    // Debug-draw all contact points and normals
    //    isGrounded = true;
    //}
}
