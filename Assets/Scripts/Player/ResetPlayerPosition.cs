using Unity.VisualScripting;
using UnityEngine;

public class ResetPlayerPosition : MonoBehaviour
{

    private float startingXPos = 0;
    private float startingYPos = 0;
    private float startingZPos = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Vector3 newPosition = new Vector3(startingXPos, startingYPos, startingZPos);
            other.transform.position = newPosition;
            other.attachedRigidbody.linearVelocityX = 0;
            other.attachedRigidbody.linearVelocityY = 0;
        }
        
    }

}
