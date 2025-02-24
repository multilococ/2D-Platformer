using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 10f;

    [SerializeField] private GroundChecker _groundChecker;

    public void MakeJamp(Rigidbody2D rigidbody2D)
    {
        if (_groundChecker.IsGrounded)
            rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}