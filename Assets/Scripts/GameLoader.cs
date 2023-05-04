using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameLoader : MonoBehaviour
{
    [Inject]
    public StateCache cache;

    public void LoadGame(SaveData saveData) => StartCoroutine(Load(saveData));

    private IEnumerator Load(SaveData saveData)
    {
        DontDestroyOnLoad(gameObject);

        yield return SceneManager.LoadSceneAsync(saveData.sceneName);

        cache.PreloadCache(saveData.data);

        // Preloading the cache before changing the scene means the player's position
        // will be overwritten in the cache when the scene changes, as it will be destroyed.
        // But preloading the cache after the scene change means the player will have already
        // attempted to read its state from the cache, so won't do so again, so we need to
        // find all active IPreserveState instances and load their state from the cache now
        var instances = FindObjectsOfType<MonoBehaviour>()
            .OfType<IPreserveState>();

        foreach (var instance in instances)
        {
            cache.Load(instance);
        }

        Destroy(gameObject);
    }
}
