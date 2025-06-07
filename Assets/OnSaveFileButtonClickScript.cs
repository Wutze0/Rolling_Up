using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnSaveFileButtonClickScript : MonoBehaviour
{
    public Button SaveFileButton1;
    public Button SaveFileButton2;
    public Button SaveFileButton3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SaveFileButton1.onClick.AddListener(() => onSaveFileButton1Click());
        SaveFileButton2.onClick.AddListener(() => onSaveFileButton2Click());
        SaveFileButton3.onClick.AddListener(() => onSaveFileButton3Click());

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void onSaveFileButton1Click()
    {
        PlayerPrefs.SetInt("SaveFileSlot", 1);
        loadGameScene();
        DataPersistenceManager.instance.LoadGame();
    }
    private void onSaveFileButton2Click()
    {
        PlayerPrefs.SetInt("SaveFileSlot", 2);
        loadGameScene();
        DataPersistenceManager.instance.LoadGame();
    }
    private void onSaveFileButton3Click()
    {
        PlayerPrefs.SetInt("SaveFileSlot", 3);
        loadGameScene();
        DataPersistenceManager.instance.LoadGame();
    }

    private void loadGameScene()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

}
