using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SaveGame : MonoBehaviour
{
    [Inject]
    public StateCache cache;

    [Inject]
    public ISaveDataWriter writer;

    public void Save()
    {
        var data = new SaveData
        {
            sceneName = SceneManager.GetActiveScene().name,
            data = CollectAllStateEntries()
        };

        writer.Write(data);
    }

    private Dictionary<string, GameData> CollectAllStateEntries()
    {
        var cachedEntries = cache.GetAllCacheEntries();
        var activeInstances = FindObjectsOfType<MonoBehaviour>()
            .OfType<IPreserveState>();

        var allStateEntries = new Dictionary<string, GameData>(cachedEntries);
        foreach (var instance in activeInstances)
        {
            // Make sure we overwrite any cached state with the latest active state
            var state = instance.GetState();
            allStateEntries[instance.ObjectId] = new GameData
            {
                dataTypeName = state.GetType().FullName,
                data = state
            };
        }

        return allStateEntries;
    }
}
