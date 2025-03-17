using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private float _currentValue;

    public event Action<float> Changed;

    private void Awake()
    {
        _currentValue = 0;
    }

    public void Add(float value)
    {
        if (value > 0)
        {
            _currentValue += value;
            Changed?.Invoke(_currentValue);
        }
    }
}
