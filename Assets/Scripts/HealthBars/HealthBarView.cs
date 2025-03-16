using UnityEngine;
using UnityEngine.UI;

public class HealthBarView : MonoBehaviour
{
    [SerializeField] private Health _health;

    [SerializeField] protected Slider _slider;

    protected float _maxBarValue = 100;
    protected float _maxHealthValue;

    private void Awake()
    {
        _slider.maxValue = _maxBarValue;
        _maxHealthValue = _health.Max;
        ChangeValue(_health.Current);
    }

    private void OnEnable()
    {
        _health.Changed += ChangeValue;
    }

    private void OnDisable()
    {
        _health.Changed -= ChangeValue;
    }

    protected virtual void ChangeValue(float value) 
    {
        float percent = value / _maxHealthValue * _maxBarValue;

        _slider.value = percent;  
    }
}
