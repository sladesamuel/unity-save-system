using System.Collections;
using UnityEngine.SceneManagement;

public class SceneSwitcher
{
    private string previousSceneName;

    public IEnumerator LoadSceneAsync(string sceneName, LoadSceneMode mode)
    {
        previousSceneName = SceneManager.GetActiveScene().name;

        yield return SceneManager.LoadSceneAsync(sceneName, mode);
    }

    public IEnumerator LoadPreviousSceneAsync()
    {
        yield return SceneManager.LoadSceneAsync(previousSceneName, LoadSceneMode.Single);
    }
}
