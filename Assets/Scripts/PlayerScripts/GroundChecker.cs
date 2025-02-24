using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private float _overlapRadius = 0.1f;

    private const string Ground = nameof(Ground);

    private LayerMask groundMask;

    private bool _isGrounded;

    public bool IsGrounded => _isGrounded;

    private void Awake()
    {
        groundMask = LayerMask.GetMask(Ground);
    }

    private void FixedUpdate()
    {
        _isGrounded = HasGround();
    }

    public bool HasGround()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, _overlapRadius, groundMask);

        return hit != null && hit.TryGetComponent(out Ground ground);
    }
}
