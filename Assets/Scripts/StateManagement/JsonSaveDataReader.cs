using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

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
        var entries = new Dictionary<string, GameData>(saveData.data);

        foreach (var entry in saveData.data)
        {
            var data = InstantiateGameData(entry.Value);
            Debug.Log($"Resulting data type: {data.GetType().FullName}");
            entries[entry.Key] = new GameData
            {
                dataTypeName = entry.Value.dataTypeName,
                data = data
            };
        }
    }

    private static object InstantiateGameData(GameData gameData)
    {
        Debug.Log($"Instantiating {gameData.dataTypeName}...");
        Debug.Log(gameData.data.ToString());

        var type = Type.GetType(gameData.dataTypeName);
        var jsonObject = (JObject)gameData.data;

        return jsonObject.ToObject(type);
    }
}
