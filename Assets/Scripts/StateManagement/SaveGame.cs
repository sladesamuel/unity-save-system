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

    private Dictionary<string, object> CollectAllStateEntries()
    {
        var cachedEntries = cache.GetAllCacheEntries();
        var activeInstances = FindObjectsOfType<MonoBehaviour>()
            .OfType<IPreserveState>();

        var allStateEntries = new Dictionary<string, object>(cachedEntries);
        foreach (var instance in activeInstances)
        {
            // Make sure we overwrite any cached state with the latest active state
            allStateEntries[instance.ObjectId] = instance.GetState();
        }

        return allStateEntries;
    }
}
