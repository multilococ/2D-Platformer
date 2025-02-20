using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _runSpeed = 2f;

    private readonly string Horizontal = nameof(Horizontal);

    private Vector2 _movementDirection;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float axisX = Input.GetAxisRaw(Horizontal);

        _movementDirection.x = axisX;
        _movementDirection.x *= _runSpeed;
        _movementDirection.y = _rigidbody.velocity.y;
        _rigidbody.velocity = _movementDirection;
    }
}
