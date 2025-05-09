using UnityEngine;

public interface IDataPersistence //Interface that every important GameObject should implement. (if the GameObject needs to be saved)
{
    void LoadData(GameData data)
    {
        
    }

    void SaveData(GameData data)
    {
    
    }

}
