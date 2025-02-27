using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private const string Ground = nameof(Ground);

    [SerializeField] private float _overlapRadius = 0.1f;

    private LayerMask _groundMask;

    public bool IsGrounded { get; private set; }

    private void Awake()
    {
        _groundMask = LayerMask.GetMask(Ground);
    }

    private void FixedUpdate()
    {
        IsGrounded = HasGround();
    }

    public bool HasGround()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, _overlapRadius, _groundMask);

        return hit != null && hit.TryGetComponent(out Ground ground);
    }
}
