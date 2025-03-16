using System.Collections;
using UnityEngine;

public class SmoothHealthBarView : HealthBarView
{
    [SerializeField] private float _smothDecreseDuration = 0.5f;

    private Coroutine _coroutine;

    protected override void ChangeValue(float value)
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(DecreaseValueSmoothly(value));
        }
        else
        {
            StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(DecreaseValueSmoothly(value));
        }
    }

    private IEnumerator DecreaseValueSmoothly(float target)
    {
        float dealapsedTime = 0.0f;
        float priviosValue = _slider.value;
        float percent = target / _maxHealthValue * _maxBarValue;

        while (dealapsedTime < _smothDecreseDuration)
        {
            dealapsedTime += Time.deltaTime;

            float normalazedTime = dealapsedTime / _smothDecreseDuration;
            float intemindateValue = Mathf.Lerp(priviosValue, percent, normalazedTime);

            _slider.value = intemindateValue;

            yield return null;
        }
    }
}
