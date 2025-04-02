using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSwitchScenesScript : MonoBehaviour
{
    //This naming goes from left to right (when looking at the scene)
    public Collider2D newGamePlatformCollider;
    public Collider2D settingsPlatformCollider;
    public Collider2D loadGamePlatformCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) //If the player presses Escape, he will get redirected to the main menu
        {
            SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //depending on which platform the player touches, he gets redirected
        if(collision.collider == newGamePlatformCollider)
        {
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }
        else if(collision.collider == settingsPlatformCollider)
        {
            SceneManager.LoadScene("SettingsScene", LoadSceneMode.Single);

        }
    }
}
