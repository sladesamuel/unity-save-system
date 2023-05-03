using UnityEngine;
using Zenject;

public class PauseGame : MonoBehaviour
{
    [Inject]
    public SceneSwitcher sceneSwitcher;

    public void Pause()
    {
        StartCoroutine(sceneSwitcher.LoadSceneAsync(Scenes.MenuScene));
    }
}
