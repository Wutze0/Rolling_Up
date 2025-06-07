using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpScript : MonoBehaviour
{
    public Rigidbody2D _player;
    public LayerMask _groundLayer;
    private const float jumpHeight = 10f;
    private KeyCode jumpKey = KeyCode.Space;
    public bool isGrounded; //variable to prevent double jumping / jumping in the air
    public bool canFly = false;
    private float steepnessOfJumpablePlatforms = (float)0.2; //The lower the value, the steeper the platform can be to still be jumpable, e.g.0 = Wall, 0.1 very steep slope
    private HashSet<Collider2D> groundedColliders = new HashSet<Collider2D>();
    void Update()
    {

        if (Input.GetKeyDown(jumpKey) && (isGrounded || canFly))
        {
            _player.linearVelocityY = jumpHeight;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal.y > steepnessOfJumpablePlatforms)
                {
                    groundedColliders.Add(collision.collider);
                    break;
                }
            }
        }

        UpdateIsGrounded();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (groundedColliders.Contains(collision.collider))
        {
            groundedColliders.Remove(collision.collider);
        }

        UpdateIsGrounded();
    }

    private void UpdateIsGrounded()
    {
        isGrounded = groundedColliders.Count > 0;
    }


    //private void OnCollisionEnter2D(Collision2D collision)
    //{


    //    if (collision.gameObject.CompareTag("Ground")) //Only increment the collidingPlatformsAmount varaible if the player is touching ground
    //    {
    //        for (int i = 0; i < collision.GetContacts(collision.contacts); i++)
    //        {
    //            if (collision.GetContact(i).normal.y <= 1 && collision.GetContact(i).normal.y > steepnessOfJumpablePlatforms) //Check for each collision, if it is touching the top, if not the player is not on the ground.
    //            {
    //                collidingPlatformsAmount++;
    //                i = collision.GetContacts(collision.contacts) + 1; //Exit the for-loop.
    //            }

    //        }
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


    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        for (int i = 0; i < collision.GetContacts(collision.contacts); i++)
    //        {
    //            if (collision.GetContact(i).normal.y <= 1 && collision.GetContact(i).normal.y > steepnessOfJumpablePlatforms) //Check for each collision, if it is touching the top, if not the player is not on the ground.
    //            {
    //                collidingPlatformsAmount--;
    //                i = collision.GetContacts(collision.contacts) + 1; //Exit the for-loop.
    //            }
    //        }
    //    }

    //    if (collidingPlatformsAmount > 0) //If the player is touching at least 1 collision, he is still able to jump, if he is touching the platform at the top
    //    {
    //        isGrounded = true;
    //    }
    //    else
    //    {
    //        isGrounded = false;
    //    }

    //}




    public void setJumpKey(KeyCode key)
    {
        jumpKey = key;
    }

    public KeyCode getJumpKey()
    {
        return jumpKey;
    }


}
