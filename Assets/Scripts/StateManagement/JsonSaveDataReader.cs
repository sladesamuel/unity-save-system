using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class JsonSaveDataReader : SaveDataHandler, ISaveDataReader
{
    public SaveData Read()
    {
        string filePath = GetFilePath(DefaultFilename);
        if (!File.Exists(filePath))
        {
            return null;
        }

        string content = File.ReadAllText(filePath);
        var saveData = JsonConvert.DeserializeObject<SaveData>(content);

        InstantiateGameDataTypes(saveData);

        return saveData;
    }

    private static void InstantiateGameDataTypes(SaveData saveData)
    {
        var entries = new Dictionary<string, GameData>();

        foreach (var entry in saveData.data)
        {
            var data = InstantiateGameData(entry.Value);
            entries[entry.Key] = new GameData
            {
                dataTypeName = entry.Value.dataTypeName,
                data = data
            };
        }

        saveData.data = entries;
    }

    private static object InstantiateGameData(GameData gameData)
    {
        var type = Type.GetType(gameData.dataTypeName);
        var jsonObject = (JObject)gameData.data;

        return jsonObject.ToObject(type);
    }
}
