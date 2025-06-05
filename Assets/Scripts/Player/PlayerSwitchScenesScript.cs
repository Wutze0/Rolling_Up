using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSwitchScenesScript : MonoBehaviour
{
    //This naming goes from left to right (when looking at the scene)
    public Collider2D newGamePlatformCollider;
    public Collider2D settingsPlatformCollider;
    public Collider2D loadGamePlatformCollider;
    private bool isPaused;
#nullable enable
    public GameObject? pauseMenu; //nullable GameObject variable.
#nullable disable

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu != null)
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape) && pauseMenu == null)
        {
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
            Time.timeScale = 1f;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //depending on which platform the player touches, he gets redirected
        if (collision.collider == newGamePlatformCollider)
        {
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }
        else if (collision.collider == settingsPlatformCollider)
        {
            SceneManager.LoadScene("SettingsScene", LoadSceneMode.Single);

        }
    }
}
