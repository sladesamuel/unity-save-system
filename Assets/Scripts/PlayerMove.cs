using UnityEngine;
using UnityEngine.UI;
using Zenject;

public struct PlayerState
{
    public Vector3 position;
}

public class PlayerMove : MonoBehaviour, IPreserveState<PlayerState>
{
    private const float Speed = 3f;

    public Text playerPositionText;

    [Inject]
    public StateCache stateCache;

    public string ObjectId => name;

    public PlayerState GetState() =>
        new PlayerState
        {
            position = transform.position
        };

    public void LoadState(object state) => LoadState((PlayerState)state);

    public void LoadState(PlayerState state) =>
        transform.position = state.position;

    void Awake() => stateCache.Load(this);

    object IPreserveState.GetState()
    {
        throw new System.NotImplementedException();
    }

    void OnDestroy() => stateCache.Store(this);

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(horizontal, vertical, 0f) * Time.deltaTime * Speed;

        playerPositionText.text = transform.position.ToString();
    }
}
