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
        {
            _buttonpressed = true;

            if (Input.GetKeyDown(moveRight))
            {
                direction = 1; //1: player moves to the right
            }
            else { direction = -1; } //-1: player moves to the left
        }

        if (Input.GetKeyUp(moveRight) || Input.GetKeyUp(moveLeft))
        {
            _buttonpressed = false;
        }

        if (_buttonpressed)
        {
            timeDifference += Time.deltaTime;
            if (timeDifference > 0.1)
            {
                _player.linearVelocityX += acceleration * direction;
                if (jumpScript.isGrounded)
                {
                    _player.linearVelocityX += acceleration * direction;
                }
                else
                {
                    _player.linearVelocityX += acceleration * inAirAccelerationMultiplayer * direction;

                }




                timeDifference = 0;
            }
        }
        
        _stone.transform.Rotate(0, 0, _player.linearVelocityX * stoneRotationSpeedMultiplier * -1); //-1 because a positive rotation turns to the left but we want it to turn to the right
    }
}
