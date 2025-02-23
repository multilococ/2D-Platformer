using UnityEngine;

public class GroundChecker : MonoBehaviour 
{
    [SerializeField] private Player _player;

    private readonly string Ground = nameof(Ground);

    private Rigidbody2D _rigidbody2D;
    
    private float _minDistanceToGround = 0.05f;

    private bool _isGrounded;

    public bool IsGrounded => _isGrounded;

    private void Awake()
    {
        _rigidbody2D = _player.GetRigidbody;
    }

    private void Update()
    {
        _isGrounded = GetGroundUnderFootState();
    }

    public bool GetGroundUnderFootState()
    {
        RaycastHit2D hit = Physics2D.Raycast(_rigidbody2D.position, Vector2.down, _minDistanceToGround, LayerMask.GetMask(Ground));

        return hit.collider != null;
    }
}
