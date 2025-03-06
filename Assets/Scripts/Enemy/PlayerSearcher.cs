using UnityEngine;

public class PlayerSearcher : MonoBehaviour
{
    [SerializeField] private float _overlapRadius = 5f;
    [SerializeField] private LayerMask _playerMask;

    public Transform Target { get; private set; }

    private void Awake()
    {
        Target = null;
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
