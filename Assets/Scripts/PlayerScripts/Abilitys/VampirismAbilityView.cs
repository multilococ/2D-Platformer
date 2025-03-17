using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VampirismAbilityView : MonoBehaviour
{
    [SerializeField] private VampirismAbility _vampirismAbility;
    [SerializeField] private Image _mouseImage;
    [SerializeField] private TextMeshProUGUI _coolDownTimerText;
    [SerializeField] private TextMeshProUGUI _actionTimeText;

    private float _coolDownTime;
    private float _actionTime;

    private void Awake()
    {
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
        StartCoroutine(StartTimer(_actionTime, _actionTimeText));
    }

    private void StartCoolDownTimer()
    {
        StartCoroutine(StartTimer(_coolDownTime, _coolDownTimerText));
    }

    private void ShowMouse()
    {
        _mouseImage.enabled = true;
    }

    private IEnumerator StartTimer(float startingTime, TextMeshProUGUI textUI)
    {
        float time = startingTime;

        while (startingTime > 0)
        {
            yield return new WaitForSeconds(1f);

            startingTime -= 1f;
            textUI.text = startingTime.ToString();
        }

        textUI.text = time.ToString();
    }
}
