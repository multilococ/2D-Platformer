using TMPro;
using UnityEngine;

public class TextHealthIndicatorView : MonoBehaviour
{
    [SerializeField] private Health _health;

    [SerializeField] private TextMeshProUGUI _currentValueText;
    [SerializeField] private TextMeshProUGUI _maxValueText;

    private float _maxValue;
    private float _currenValue;

    private void Awake()
    {
        _maxValue = _health.Max;
        _currenValue = _health.Current;
        _currentValueText.text = _currenValue.ToString();
        _maxValueText.text = _maxValue.ToString();
    }

    private void OnEnable()
    {
        _health.Changed += UpdateValues;
    }

    private void OnDisable()
    {
        _health.Changed -= UpdateValues;
    }

    protected virtual void UpdateValues(float value)
    {
        _currentValueText.text = value.ToString();
    }
}
