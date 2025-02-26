using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _runSpeed = 10f;

    public void Move(Rigidbody2D _rigidbody,float direction)
    {
        _rigidbody.velocity = new Vector2( direction * _runSpeed, _rigidbody.velocity.y);
    }
}