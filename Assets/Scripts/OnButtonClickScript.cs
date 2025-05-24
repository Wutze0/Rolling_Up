using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnButtonClickScript : MonoBehaviour
{
    public Button continueButton;
    public Button saveAndQuitButton;
    public Button saveButton;
    public Button settingsButton;
    public GameObject pauseMenu;


    // Start is called once before the first execution of Update after the MonoBehaviour is created


    void Start()
    {
        continueButton.onClick.AddListener(() => onContinueButtonButtonClick());
        saveAndQuitButton.onClick.AddListener(() => onSaveAndQuitButtonButtonClick());
        saveButton.onClick.AddListener(() => onSaveButtonButtonClick());
        settingsButton.onClick.AddListener(() => onSettingsButtonButtonClick());


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void onContinueButtonButtonClick()
    {
        PlayerPrefs.SetInt("IsInPauseScene", 0);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; //set the time to normal
    }

    private void onSaveAndQuitButtonButtonClick() //Only works in a build!
    {
        DataPersistenceManager.instance.SaveGame();
        Application.Quit();

    }
    private void onSaveButtonButtonClick()
    {
        DataPersistenceManager.instance.SaveGame();
    }
    private void onSettingsButtonButtonClick()
    {
        DataPersistenceManager.instance.SaveGame();
        SceneManager.LoadScene("SettingsScene", LoadSceneMode.Single);
    }


}
