using System;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    private readonly string Horizontal = nameof(Horizontal);
    private readonly string Jump = nameof(Jump);

    private float _axisX;

    public float GetAxisX => _axisX;

    public event Action PressedSpace;
    public event Action<float> Turned;

    private void Update()
    {
        _axisX = Input.GetAxisRaw(Horizontal);
        
        if(_axisX != 0)
            Turned?.Invoke(_axisX);

        if (Input.GetButtonDown(Jump)) 
            PressedSpace?.Invoke();
    }
}
