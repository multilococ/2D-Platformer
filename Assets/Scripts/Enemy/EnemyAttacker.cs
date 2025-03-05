using System.Collections;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private float _damage = 5f;
    [SerializeField] private float _delay = 2f;

    WaitForSeconds _waitForSeconds;

    public bool CanAttack { get; private set; }
    
    private void Awake()
    {
        CanAttack = true;
        _waitForSeconds = new WaitForSeconds(_delay);
    }

    public void MakeAttack(Transform target) 
    {
        target.TryGetComponent(out IDamageable damageable);

        if (CanAttack == true && damageable != null)
        {
            Debug.Log("Enemy Attacking");
            damageable.TakeDamage(_damage);
            CanAttack = false;
            StartCoroutine(AttackDelay());
        }
    }

    private IEnumerator AttackDelay() 
    {
        yield return _waitForSeconds;
        CanAttack = true;
    }   
}
