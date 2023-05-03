using System.Collections;
using UnityEngine.SceneManagement;

public class SceneSwitcher
{
    private Scenes previousScene;

    public IEnumerator LoadSceneAsync(Scenes scene)
    {
        previousScene = System.Enum.Parse<Scenes>(SceneManager.GetActiveScene().name);

        yield return SceneManager.LoadSceneAsync(scene.ToString());
    }

    public IEnumerator LoadPreviousSceneAsync()
    {
        yield return SceneManager.LoadSceneAsync(previousScene.ToString(), LoadSceneMode.Single);
    }
}
