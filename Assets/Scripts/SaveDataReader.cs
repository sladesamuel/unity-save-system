using System.IO;
using Newtonsoft.Json;

public class SaveDataReader : SaveDataHandler
{
    public SaveData Read()
    {
        string filePath = GetFilePath(DefaultFilename);
        if (!File.Exists(filePath))
        {
            return null;
        }

        string content = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<SaveData>(content);
    }
}
