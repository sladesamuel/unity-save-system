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
    public SaveDataWriter writer;

    public void Save()
    {
        var cachedEntries = cache.GetAllCacheEntries();
        var allStateEntries = FindObjectsOfType<MonoBehaviour>()
            .OfType<IPreserveState>()
            .Select(instance => new KeyValuePair<string, object>(instance.ObjectId, instance.GetState()))
            .Union(cachedEntries)
            .ToDictionary(entry => entry.Key, entry => entry.Value);

        var data = new SaveData
        {
            sceneName = SceneManager.GetActiveScene().name,
            data = allStateEntries
        };

        writer.Write(data);
    }
}
