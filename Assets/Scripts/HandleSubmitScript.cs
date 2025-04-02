using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HandleSubmitScript : MonoBehaviour
{
    private PlayerMovementScript movementScript;
    public TMP_InputField leftInputField;
    public TMP_InputField rightInputField;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movementScript = FindFirstObjectByType<PlayerMovementScript>(); // To get access to the methods that set the keybinds

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Return) && leftInputField.isFocused)//changes the key, which is used to move to the left
        {
            KeyCode code = (KeyCode)System.Enum.Parse(typeof(KeyCode), leftInputField.text, true); //parses the input string into a KeyCode

            movementScript.setMoveLeftKey(code); //sets the new keybind

        }
        else if(Input.GetKeyUp(KeyCode.Return) && rightInputField.isFocused)//changes the key, which is used to move to the right
        {
            KeyCode code = (KeyCode)System.Enum.Parse(typeof(KeyCode), rightInputField.text, true); //parses the input string into a KeyCode

            movementScript.setMoveRightKey(code); //sets the new keybind
        }
    }
}
