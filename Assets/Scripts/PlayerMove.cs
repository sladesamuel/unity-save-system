using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private const float Speed = 3f;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(horizontal, vertical, 0f) * Time.deltaTime * Speed;
    }
}
