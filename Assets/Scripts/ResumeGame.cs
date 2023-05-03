using UnityEngine;
using Zenject;

public class ResumeGame : MonoBehaviour
{
    [Inject]
    public SceneSwitcher sceneSwitcher;

    public void Resume()
    {
        StartCoroutine(sceneSwitcher.LoadPreviousSceneAsync());
    }
}
