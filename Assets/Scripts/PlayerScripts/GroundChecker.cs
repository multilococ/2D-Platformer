using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private const string Ground = nameof(Ground);

    [SerializeField] private float _overlapRadius = 0.1f;

    private LayerMask groundMask;

    public bool IsGrounded { private set; get; }

    private void Awake()
    {
        groundMask = LayerMask.GetMask(Ground);
    }

    private void FixedUpdate()
    {
        IsGrounded = HasGround();
    }

    public bool HasGround()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, _overlapRadius, groundMask);

        return hit != null && hit.TryGetComponent(out Ground ground);
    }
}
