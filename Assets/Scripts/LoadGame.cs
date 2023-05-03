using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class LoadGame : MonoBehaviour
{
    [Inject]
    public StateCache cache;

    [Inject]
    public SaveDataReader reader;

    public void Load()
    {
        var saveData = reader.Read();
        if (saveData != null)
        {
            StartCoroutine(Load(saveData));
        }
    }

    private IEnumerator Load(SaveData saveData)
    {
        DontDestroyOnLoad(gameObject);

        yield return SceneManager.LoadSceneAsync(saveData.sceneName);

        // TODO: Preloading the cache before changing the scene means the player's position
        //       will be overwritten in the cache when the scene changes, as it will be destroyed.
        //       But preloading the cache after the scene change means the player will have already
        //       attempted to read its state from the cache, so won't do so again.
        cache.PreloadCache(saveData.data);

        Destroy(gameObject);
    }
}
