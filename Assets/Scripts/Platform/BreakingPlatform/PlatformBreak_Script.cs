using UnityEngine;

public class PlatformBreak_Script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public BoxCollider2D hitbox;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitbox.isTrigger = true;
        if (collision.gameObject.CompareTag("Player"))
        {
            new WaitForSeconds(1);
            hitbox.isTrigger = true;
            new WaitForSeconds(10);
            hitbox.isTrigger = false;
        }
        
    }

}

