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
        if (Input.GetKey(moveRight))
        {
            _buttonpressed = true;
            direction = 1;
        }
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
            if (timeDifference > 0.1f)
            {
                float appliedAcceleration = acceleration * direction;

                    if (!jumpScript.isGrounded)
                    {
                        appliedAcceleration *= inAirAccelerationMultiplayer;
                    }




                    _player.linearVelocityX += appliedAcceleration;
                    timeDifference = 0;
                }

                _player.linearVelocityX += appliedAcceleration;
                timeDifference = 0;
            }
        }

        _stone.transform.Rotate(0, 0, _player.linearVelocityX * stoneRotationSpeedMultiplier * -1);
    }



