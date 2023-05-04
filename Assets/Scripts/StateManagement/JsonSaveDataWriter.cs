using System.IO;
using Newtonsoft.Json;

public class JsonSaveDataWriter : SaveDataHandler, ISaveDataWriter
{
    public void Write(SaveData data)
    {
        string filePath = GetFilePath(DefaultFilename);
        string content = JsonConvert.SerializeObject(data);

        File.WriteAllText(filePath, content);
    }
}
