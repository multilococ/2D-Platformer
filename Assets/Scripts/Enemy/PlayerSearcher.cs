using UnityEngine;

public class PlayerSearcher : MonoBehaviour
{
    private const string Player = nameof(Player);

    [SerializeField] private float _overlapRadius = 5f;

    private LayerMask _playerMask;

    public Transform Target { get; private set; }

    private void Awake()
    {
        Target = null;
        _playerMask = LayerMask.GetMask(Player);
    }

    private void FixedUpdate()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, _overlapRadius, _playerMask);

        if (hit != null)
            Target = hit.transform;
        else
            Target = null;
    }
}
