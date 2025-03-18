using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VampirismAbilityView : MonoBehaviour
{
    [SerializeField] private VampirismAbility _vampirismAbility;
    [SerializeField] private Image _mouseImage;
    [SerializeField] private TextMeshProUGUI _coolDownTimerText;
    [SerializeField] private TextMeshProUGUI _actionTimeText;

    private ReverseTimer _reverseTimer;

    private float _coolDownTime;
    private float _actionTime;

    private void Awake()
    {
        _reverseTimer = new ReverseTimer();
        _coolDownTime = _vampirismAbility.CoolDownTime;
        _actionTime = _vampirismAbility.ActionTime;
        _coolDownTimerText.text = _coolDownTime.ToString();
        _actionTimeText.text = _actionTime.ToString();
        _mouseImage.enabled = true;
    }

    private void OnEnable()
    {
        _vampirismAbility.StartUsing += UseAbility;
        _vampirismAbility.EndEffect += StartCoolDownTimer;
        _vampirismAbility.Availabled += ShowMouse;
    }

    private void OnDisable()
    {
        _vampirismAbility.StartUsing -= UseAbility;
        _vampirismAbility.EndEffect -= StartCoolDownTimer;
        _vampirismAbility.Availabled -= ShowMouse;
    }

    private void UseAbility()
    {
        _mouseImage.enabled = false;
        StartCoroutine(_reverseTimer.Start(_actionTime, _actionTimeText));
    }

    private void StartCoolDownTimer()
    {
        StartCoroutine(_reverseTimer.Start(_coolDownTime, _coolDownTimerText));
    }

    private void ShowMouse()
    {
        _mouseImage.enabled = true;
    }
}
