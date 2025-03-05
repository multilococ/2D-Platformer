using System;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    private readonly int LeftMouseButon = 0;

    private readonly string Horizontal = nameof(Horizontal);
    private readonly string Jump = nameof(Jump);

    public float AxisX { get; private set; }

    public event Action SpacePresed;
    public event Action LeftMouseButtonPressed;

    private void Update()
    {
        AxisX = Input.GetAxisRaw(Horizontal);

        if (Input.GetButtonDown(Jump))
         SpacePresed?.Invoke();

        if(Input.GetMouseButtonDown(LeftMouseButon))
            LeftMouseButtonPressed?.Invoke();
    }
}
