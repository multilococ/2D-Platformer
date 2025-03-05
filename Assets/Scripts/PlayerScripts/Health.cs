using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable , IHealingable
{
    private float _max = 100;
    private float _min = 0;
    private float _current = 100;

    public event Action<float> Changed;
    public event Action Died;
    public event Action TakedDamage;

    public void TakeDamage(float damage)
    {
        TakedDamage?.Invoke();

        _current -= damage;

        if (_current < _min)
        {
            _current = _min;
        }

        Changed?.Invoke(_current);

        if (_current == _min)
        {
            Died?.Invoke();
        }

        Debug.Log(transform.name + " Health : " + _current);
    }

    public void ReceiveTreatment(float treatment)
    {
        _current += treatment;

        if (_current > _max)
            _current = _max;

        Debug.Log("Riceived Treatment" + transform.name + " hp : " + _current);
        Changed?.Invoke(_current);
    }
}