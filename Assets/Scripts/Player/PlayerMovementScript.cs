using System.IO;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour, IDataPersistence
{
    public Rigidbody2D _player;
    public GameObject _stone;
    public Animator _animator;
    public Transform _sisyphosTransform;
    private float _sisyphosWalkingSpeedDivisor = 10;
    private const float stoneRotationSpeedMultiplier = 0.2f;
    private float timeDifference = 0;
    private bool _buttonpressed;
    private int direction;
    public float acceleration = 0.9f;
    private KeyCode moveLeft = KeyCode.LeftArrow;
    private KeyCode moveRight = KeyCode.RightArrow;
    private PlayerJumpScript jumpScript; //Reference to the jumpScript
    private const float inAirAccelerationMultiplier = 0.1f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator.StopPlayback();
        jumpScript = GetComponent<PlayerJumpScript>(); // Access to the jumpScript
        initializeKeybinds(); //Gets all the set Keybinds for moving left and right

        _player.freezeRotation = true; //freeze the rotation of Sisyphos
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.linearVelocityX == 0)
        {
            _animator.speed = 0;
        }
        else if (_player.linearVelocityX > 0)
        {
            _animator.speed = _player.linearVelocityX / _sisyphosWalkingSpeedDivisor;

        }
        else
        {
            _animator.speed = _player.linearVelocityX / -_sisyphosWalkingSpeedDivisor;

        }


        if (Input.GetKey(moveRight))
        {
            _buttonpressed = true;
            direction = 1; //positive -> stone is moving to the right
            if (_sisyphosTransform.rotation.y != 0)
            {
                _sisyphosTransform.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else if (Input.GetKey(moveLeft))
        {
            _buttonpressed = true;
            direction = -1; //negative -> stone is moving to the left
            if (_sisyphosTransform.rotation.y != 180)
            {
                _sisyphosTransform.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
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
                    appliedAcceleration *= inAirAccelerationMultiplier; //If the player is in the air, the acceleration will decrease.
                }


                _player.linearVelocityX += appliedAcceleration;
                timeDifference = 0;
            }
        }
        _stone.transform.Rotate(0, 0, _player.linearVelocityX * stoneRotationSpeedMultiplier * -1);
    }

    public void setMoveLeftKey(KeyCode key)
    {
        moveLeft = key;
        saveKeybinds();

    }

    public void setMoveRightKey(KeyCode key)
    {
        moveRight = key;
        saveKeybinds();
    }

    public void setJumpKey(KeyCode key)
    {
        jumpScript.setJumpKey(key);
        saveKeybinds();
    }

    private void initializeKeybinds() //Method to get and set the set keybinds for the game.
    {
        string[] keys = new string[100]; //might have to change this
        if (!File.Exists(Application.persistentDataPath + "/Keybinds.txt"))
        {
            //File.Create(Application.persistentDataPath + "/Keybinds.txt");
            File.WriteAllText(Application.persistentDataPath + "/Keybinds.txt", "moveLeft:" + KeyCode.A.ToString() + "\nmoveRight:" + KeyCode.D.ToString() + "\njumpKey:" + KeyCode.Space.ToString());
            keys[0] = "A";
            keys[1] = "D";
            keys[2] = "Space";
        }
        else
        {
            string content = File.ReadAllText(Application.persistentDataPath + "/Keybinds.txt");
            string[] lines = new string[3];         //String size might have to be increased because we are not saving the jump button yet
            lines = content.Split('\n', System.StringSplitOptions.RemoveEmptyEntries);
           

            int i = 0;
            foreach (string l in lines) //foreach to get all the actural keybinds
            {
                keys[i] = l.Split(':', System.StringSplitOptions.RemoveEmptyEntries)[1].Trim();
                i++;
            }

            
        }
        setMoveLeftKey(stringToKeyCode(keys[0]));
        setMoveRightKey(stringToKeyCode(keys[1]));
        setJumpKey(stringToKeyCode(keys[2]));

    }

    private KeyCode stringToKeyCode(string key) //Method to parse a string to KeyCode
    {
        KeyCode code = (KeyCode)System.Enum.Parse(typeof(KeyCode), key.Trim(), true);
        return code;
    }

    private void saveKeybinds() //Method to save the changed keybinds
    {
        File.WriteAllText(Application.persistentDataPath + "/Keybinds.txt", "moveLeft: " + moveLeft.ToString() + "\nmoveRight: " + moveRight.ToString() + "\njumpKey: " + jumpScript.getJumpKey().ToString());
    }

    public void LoadData(GameData data) //Add more data that needs to be saved.
    {

        _player.position = data.playerPosition;
        _player.linearVelocity = data.playerVelocity;
    }

    public void SaveData(GameData data)
    {
        data.playerVelocity = _player.linearVelocity;
        data.playerPosition = _player.position;
    }


}



