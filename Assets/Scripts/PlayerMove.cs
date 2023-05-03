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

    public string ObjectId => name;

    object IPreserveState.GetState() => GetState();

    public PlayerState GetState() =>
        new PlayerState
        {
            position = transform.position
        };

    public void LoadState(object state) => LoadState((PlayerState)state);

    public void LoadState(PlayerState state) =>
        transform.position = state.position;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(horizontal, vertical, 0f) * Time.deltaTime * Speed;

        playerPositionText.text = transform.position.ToString();
    }
}
