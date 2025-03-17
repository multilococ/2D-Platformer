using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class VampirismAbility : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyMask;
    [SerializeField] private float _range = 5f;
    [SerializeField] private float _damage = 5f;
    [SerializeField] private float _actionTime = 6f;
    [SerializeField] private float _coolDownTime = 4f;
    [SerializeField] private float _delayBetweenDealingDamage = 1f;

    WaitForSeconds _waitForDelayDealingDamageSeconds;
    WaitForSeconds _waitForCoolDownSeconds;

    private bool _isAvailable;

    public float ActionTime => _actionTime;
    public float CoolDownTime => _coolDownTime;
    public float Range => _range;

    public Action StartUsing;
    public Action EndEffect;
    public Action Availabled;

    private void Awake()
    {
        _waitForDelayDealingDamageSeconds = new WaitForSeconds(_delayBetweenDealingDamage);
        _waitForCoolDownSeconds = new WaitForSeconds(_coolDownTime);
        _isAvailable = true;
    }

    public void Use()
    {
        if (_isAvailable == true)
        {
            Debug.Log("Ability is Active");
            _isAvailable = false;
            StartCoroutine(AttackEnemyForTiming());
        }
    }

    private Collider2D GetEnemyColliderFromArea()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _range, _enemyMask);
        Collider2D closest = null;

        if (hits.Length > 1)
        {
            closest = hits[0];

            float distanceToClosest = (closest.transform.position - transform.position).sqrMagnitude;

            for (int i = 1; i < hits.Length; i++)
            {
                float distanceToNext = (closest.transform.position - transform.position).sqrMagnitude;

                if (distanceToNext > distanceToClosest)
                {
                    distanceToClosest = distanceToNext;
                    closest = hits[i];
                }
            }
        }
        else if (hits.Length == 1) 
        {
            closest = hits.First();
        }

        return closest;
    }

    private IEnumerator AttackEnemyForTiming()
    {
        StartUsing?.Invoke();

        float currentTime = 0;

        while (currentTime < _actionTime)
        {
            Collider2D closestEnemy = GetEnemyColliderFromArea();

            if (closestEnemy != null && closestEnemy.TryGetComponent(out IDamageable damageable))
            {
                Debug.Log(closestEnemy.name + " - in Vapirism Area");
                damageable.TakeDamage(_damage);
            }

            currentTime += _delayBetweenDealingDamage;

            yield return _waitForDelayDealingDamageSeconds;
        }


        EndEffect?.Invoke();
        Debug.Log("Ability is OFF");
        StartCoroutine(WaitForCoolDown());
    }

    private IEnumerator WaitForCoolDown()
    {
        yield return _waitForCoolDownSeconds;

        _isAvailable = true;
        Debug.Log("Ability is Avaliable");
        Availabled?.Invoke();
    }
}
