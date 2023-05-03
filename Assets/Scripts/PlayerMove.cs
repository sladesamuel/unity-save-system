using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PlayerMove : MonoBehaviour
{
    private const float Speed = 3f;

    public Text playerPositionText;

    [Inject]
    public StateCache stateCache;

    void Awake()
    {
        var position = stateCache.Get("Player");
        if (position != null)
        {
            Debug.Log("PlayerMove.Awake(): Get position");
            playerPositionText.text = ((Vector3)position).ToString();
        }
        else
        {
            Debug.Log("No state found");
        }
    }

    void OnDestroy()
    {
        Debug.Log("PlayerMove.OnDestroy(): Store position");
        stateCache.Store("Player", transform.position);
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(horizontal, vertical, 0f) * Time.deltaTime * Speed;

        // playerPositionText.text = transform.position.ToString();
    }
}
