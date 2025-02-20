using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 10f;
   
    private readonly string Jump = nameof(Jump);
    private readonly string Ground = nameof(Ground);

    private Rigidbody2D _rigidbody2D;

    private float _minDistanceToGround = 0.05f;

    private bool _isGrounded;

    public bool IsGrounded => _isGrounded;

    private void Awake()
    {
        _isGrounded = true;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(_rigidbody2D.position, Vector2.down, _minDistanceToGround, LayerMask.GetMask(Ground));

        if (hit.collider != null)
        {
            _isGrounded = true;
        }
        else 
        {
            _isGrounded = false;
        }

        if (Input.GetButtonDown(Jump) && _isGrounded) 
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}
