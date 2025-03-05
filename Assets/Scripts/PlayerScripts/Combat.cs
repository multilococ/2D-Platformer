using System.Collections;
using UnityEngine;

public class Combat : MonoBehaviour
{
    private const string EnemyLayer = nameof(EnemyLayer);

    [SerializeField] private Transform _hitPoint;
    [SerializeField] private float _hitPointRadius;
    [SerializeField] private float _attackDelay = 0.3f;

    private LayerMask _enemyMask;

    private WaitForSeconds _waitForSeconds;

    private float _damage = 5;

    public bool CanAttack { get; private set; }

    private void Awake()
    {
        _enemyMask = LayerMask.GetMask(EnemyLayer);
        CanAttack = true;
        _waitForSeconds = new WaitForSeconds(_attackDelay);
    }

    public void Attack()
    {
            Collider2D hit = Physics2D.OverlapCircle(_hitPoint.position, _hitPointRadius, _enemyMask);

            if (hit != null) {
                Debug.Log(hit.name);
            }
            if (hit != null && hit.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(_damage);
            }

            CanAttack = false;
            StartCoroutine(WaitBetweenStrokes());
    }

    private IEnumerator WaitBetweenStrokes()
    {
        yield return _waitForSeconds;

        CanAttack = true;
    }
}