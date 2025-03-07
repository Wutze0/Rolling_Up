using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementScript : MonoBehaviour
{
    public Rigidbody2D _player;
    public GameObject _stone;
    private const float stoneRotationSpeedMultiplier = 5;
    private float timeDifference = 0;
    private bool _buttonpressed;
    private int direction;
    private const float acceleration = (float)0.5;
    public float acceleration = 0.9f;
    private const KeyCode moveLeft = KeyCode.LeftArrow;
    private const KeyCode moveRight = KeyCode.RightArrow;
    private PlayerJumpScript jumpScript; //Reference to the jumpScript
    private const float inAirAccelerationMultiplayer = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumpScript = GetComponent<PlayerJumpScript>(); // Access to the jumpScript

        _player.freezeRotation = true; //freeze the rotation of Sisyphos
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(moveRight) || Input.GetKeyDown(moveLeft))
        if (Input.GetKey(moveRight))
        {
            _buttonpressed = true;

            if (Input.GetKeyDown(moveRight))
            {
                direction = 1; //1: player moves to the right
            }
            else { direction = -1; } //-1: player moves to the left
            direction = 1;
        }

        if (Input.GetKeyUp(moveRight) || Input.GetKeyUp(moveLeft))
        else if (Input.GetKey(moveLeft))
        {
            _buttonpressed = true;
            direction = -1;
        }
        else
        {
            _buttonpressed = false;
        }

        if (_buttonpressed)
        {
            timeDifference += Time.deltaTime;
            {
                _player.linearVelocityX += acceleration * direction;
                if (jumpScript.isGrounded)
                {
                    _player.linearVelocityX += acceleration * direction;
                }
                else
                {
                    _player.linearVelocityX += acceleration * inAirAccelerationMultiplayer * direction;
                float appliedAcceleration = acceleration * direction;

                if (!jumpScript.isGrounded)
                {
                    appliedAcceleration *= inAirAccelerationMultiplayer;
                }




                _player.linearVelocityX += appliedAcceleration;
                timeDifference = 0;
            }
        }
    }

}
