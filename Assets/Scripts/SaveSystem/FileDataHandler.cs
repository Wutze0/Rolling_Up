using Newtonsoft.Json;
using System.IO;
public class FileDataHandler
{
    private string _dataDirPath = "";
    private string _dataFileName = "";

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        _dataDirPath = dataDirPath;
        _dataFileName = dataFileName;
    }

    public GameData Load()
    {
        string fullFilePath = Path.Combine(_dataDirPath, _dataFileName); //Different OS's have different path separators.

        GameData data = null;
        if (File.Exists(fullFilePath))
        {
            try
            {
                string dataString = "";

                dataString = File.ReadAllText(fullFilePath);

                data = JsonConvert.DeserializeObject<GameData>(dataString); //Deserialize the GameData.
            }
            catch
            {

            }

        }
        return data;
    }

    public void Save(GameData gameData)
    {
        string fullFilePath = Path.Combine(_dataDirPath, _dataFileName); //Different OS's have different path separators.
        Directory.CreateDirectory(Path.GetDirectoryName(fullFilePath));
        string serializedData = JsonConvert.SerializeObject(gameData, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        }); //Serialize all the GameData.
        File.WriteAllText(fullFilePath, serializedData);


    }



}
