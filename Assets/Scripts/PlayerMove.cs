using UnityEngine;
using UnityEngine.UI;
using Zenject;

public struct PlayerState
{
    public Vector3 position;
}

public class PlayerMove : MonoBehaviour, ICacheable<PlayerState>
{
    private const float Speed = 3f;

    public Text playerPositionText;

    [Inject]
    public StateCache stateCache;

    string ICacheable<PlayerState>.ObjectId => name;

    PlayerState ICacheable<PlayerState>.GetState() =>
        new PlayerState
        {
            position = transform.position
        };

    void ICacheable<PlayerState>.LoadState(PlayerState state) =>
        transform.position = state.position;

    void Awake() => stateCache.Load(this);
    void OnDestroy() => stateCache.Store(this);

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(horizontal, vertical, 0f) * Time.deltaTime * Speed;

        playerPositionText.text = transform.position.ToString();
    }
}
