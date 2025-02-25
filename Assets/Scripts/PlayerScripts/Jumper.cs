using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 10f;

    public void MakeJamp(Rigidbody2D rigidbody2D)
    {
        rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}