using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _runSpeed = 2f;
    [SerializeField] private UserInput _userInput;

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
        _movementDirection.x = _userInput.GetAxisX;
        _movementDirection.x *= _runSpeed;
        _rigidbody.AddForce(_movementDirection);
    }
}
