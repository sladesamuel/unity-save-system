using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    private const float Speed = 3f;

    public Text playerPositionText;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(horizontal, vertical, 0f) * Time.deltaTime * Speed;

        playerPositionText.text = transform.position.ToString();
    }
}
