using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{

    [Header("File Storage Configuration")]
    [SerializeField] private string fileName;
    public static DataPersistenceManager instance { get; set; }
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler fileDataHandler;
    private GameData gameData;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame() //TODO: player being able to create a new game in the main scene
    {
        gameData = new GameData();
    }

    public void SaveGame()
    {

        string slotFileName = $"data{PlayerPrefs.GetInt("SaveFileSlot")}.json";
        FileDataHandler handler = new FileDataHandler(Application.persistentDataPath, slotFileName);

        foreach (IDataPersistence dataPersistenceObject in dataPersistenceObjects)
        {
            dataPersistenceObject.SaveData(gameData);
        }

        handler.Save(gameData);
    }

    public void LoadGame()
    {
        string slotFileName = fileName + PlayerPrefs.GetInt("SaveFileSlot") + ".json";

        FileDataHandler handler = new FileDataHandler(Application.persistentDataPath, slotFileName);

        gameData = handler.Load();

        if (gameData == null)
        {
            NewGame();
        }

        foreach (IDataPersistence dataPersistenceObject in dataPersistenceObjects)
        {
            dataPersistenceObject.LoadData(gameData);
        }


    }


    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        MonoBehaviour[] allMonoBehaviours = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);
        List<IDataPersistence> dataPersistenceObjects = new List<IDataPersistence>();

        foreach (var monoBehaviour in allMonoBehaviours)
        {
            if (monoBehaviour is IDataPersistence dataPersistence)
            {
                dataPersistenceObjects.Add(dataPersistence);
            }
        }

        return dataPersistenceObjects;
    }

    public void DeleteSaveFile() 
    {
        string slotFileName = $"data{PlayerPrefs.GetInt("SaveFileSlot")}.json";

        File.WriteAllText(Path.Combine(Application.persistentDataPath, slotFileName), "");
    }
}
