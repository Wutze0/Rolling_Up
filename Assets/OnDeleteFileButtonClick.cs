using UnityEngine;
using UnityEngine.UI;

public class OnDeleteFileButtonClick : MonoBehaviour
{
    public Button DeleteSaveFileButton1;
    public Button DeleteSaveFileButton2;
    public Button DeleteSaveFileButton3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DeleteSaveFileButton1.onClick.AddListener(() => onDeleteSaveFileButton1Click());
        DeleteSaveFileButton2.onClick.AddListener(() => onDeleteSaveFileButton2Click());
        DeleteSaveFileButton3.onClick.AddListener(() => onDeleteSaveFileButton3Click());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void onDeleteSaveFileButton1Click()
    {
        PlayerPrefs.SetInt("SaveFileSlot", 1);
        DeleteSaveFile();
    }

    private void onDeleteSaveFileButton2Click()
    {
        PlayerPrefs.SetInt("SaveFileSlot", 2);
        DeleteSaveFile();
    }

    private void onDeleteSaveFileButton3Click()
    {
        PlayerPrefs.SetInt("SaveFileSlot", 3);
        DeleteSaveFile();
    }

    private void DeleteSaveFile() 
    {
        DataPersistenceManager.instance.DeleteSaveFile();
    }

}
