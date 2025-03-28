using UnityEngine;

public class PlayerJumpScript : MonoBehaviour
{
    public Rigidbody2D _player;
    public Transform _groundCheck;
    public LayerMask _groundLayer;
    private const float jumpHeight = 10f;
    private const KeyCode jumpKey = KeyCode.Space;

    void Update()
    {
        if (Input.GetKeyDown(jumpKey) && isGrounded())
        {
            _player.linearVelocityY = jumpHeight;
        }





    }

    public bool isGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
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

    //private void OnCollisionEnter2D(Collision2D collision)
    //{

    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        collidingPlatformsAmount++;
    //    }

    //    if (collidingPlatformsAmount > 0)
    //    {
    //        isGrounded = true;
    //    }
    //    else
    //    {
    //        isGrounded = false;
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground") )
    //    {
    //        collidingPlatformsAmount--;
    //    }


    //    if (collidingPlatformsAmount > 0)
    //    {
    //        isGrounded = true;
    //    }
    //    else
    //    {
    //        isGrounded = false;
    //    }

    //}

    //private void OnCollisionStay(Collision collisionInfo)
    //{
    //    // Debug-draw all contact points and normals
    //    isGrounded = true;
    //}
}
