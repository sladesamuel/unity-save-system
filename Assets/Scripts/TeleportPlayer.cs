using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportPlayer : MonoBehaviour
{
    public Scenes targetScene;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            StartCoroutine(Teleport());
        }
    }

    private IEnumerator Teleport()
    {
        DontDestroyOnLoad(gameObject);

        yield return SceneManager.LoadSceneAsync(targetScene.ToString(), LoadSceneMode.Single);

        var player = FindObjectOfType<PlayerMove>();
        var startPoint = FindObjectOfType<StartPoint>();

        player.transform.position = startPoint.transform.position;

        Destroy(gameObject);
    }
}
