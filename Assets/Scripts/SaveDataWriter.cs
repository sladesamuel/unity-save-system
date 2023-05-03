using System.IO;
using Newtonsoft.Json;

public class SaveDataWriter : SaveDataHandler
{
    public void Write(SaveData data)
    {
        string filePath = GetFilePath(DefaultFilename);
        string content = JsonConvert.SerializeObject(data);

        File.WriteAllText(filePath, content);
    }
}
