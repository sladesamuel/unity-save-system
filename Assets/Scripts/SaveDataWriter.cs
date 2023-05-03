using System.IO;
using UnityEngine;

public class SaveDataWriter : SaveDataHandler
{
    public void Write(SaveData data)
    {
        string filePath = GetFilePath(DefaultFilename);

        string content = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, content);
    }
}
