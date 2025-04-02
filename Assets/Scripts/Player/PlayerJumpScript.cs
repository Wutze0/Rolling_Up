using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerJumpScript : MonoBehaviour
{
    public Rigidbody2D _player;
    public Transform _groundCheck;
    public LayerMask _groundLayer;
    private const float jumpHeight = 10f;
    private const KeyCode jumpKey = KeyCode.Space;
    public bool isGrounded; //variable to prevent double jumping / jumping in the air
    public bool canFly = false;
    private int collidingPlatformsAmount = 0;

    void Update()
    {
  
        if (Input.GetKeyDown(jumpKey) && (isGrounded || canFly))
        {
            _player.linearVelocityY = jumpHeight;
        }





    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Ground")) //Only increment the collidingPlatformsAmount varaible if the player is touching ground
        {
            collidingPlatformsAmount++;
        }
        if (collidingPlatformsAmount > 0)
        {
            for(int i = 0; i < collision.GetContacts(collision.contacts); i++)
            {
                if(collision.GetContact(i).normal.y <= 1 && collision.GetContact(i).normal.y > 0.5) //Check for each collision, if it is touching the top, if not the player is not on the ground.
                {
                    isGrounded = true;
                    i = collision.GetContacts(collision.contacts) + 1; //Exit the for-loop.
                }

            }
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


        if (collidingPlatformsAmount > 0) //If the player is touching at least 1 collision, he is still able to jump
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

    }


}
