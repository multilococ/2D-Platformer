using System.Collections;
using TMPro;
using UnityEngine;

public class ReverseTimer
{
    private int _step = 1;

    WaitForSeconds _waitForSeconds;

    public IEnumerator Start(float startingTime, TextMeshProUGUI textUI)  
    {
        _waitForSeconds = new WaitForSeconds(_step);

        float time = startingTime;

        while (startingTime > 0)
        {
            yield return _waitForSeconds;

            startingTime -= _step;
            textUI.text = startingTime.ToString();
        }

        textUI.text = time.ToString();
    }
}
