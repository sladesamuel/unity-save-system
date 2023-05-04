using System.IO;
using UnityEngine;

public abstract class SaveDataHandler
{
    protected const string DefaultFilename = "file-1";

    protected static string GetFilePath(string filename) =>
        Path.Combine(Application.persistentDataPath, $"{filename}.dat");
}
