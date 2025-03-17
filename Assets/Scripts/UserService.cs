using System;
using UnityEngine;

public class UserService : MonoBehaviour
{
    private readonly int LeftMouseButon = 0;
    private readonly int RightMouseButon = 1;

    private readonly string Horizontal = nameof(Horizontal);
    private readonly string Jump = nameof(Jump);

    public float AxisX { get; private set; }

    public event Action SpacePresed;
    public event Action LeftMouseButtonPressed;
    public event Action RightMouseButtonPressed;

    private void Update()
    {
        AxisX = Input.GetAxisRaw(Horizontal);

        if (Input.GetButtonDown(Jump))
         SpacePresed?.Invoke();

        if(Input.GetMouseButtonDown(LeftMouseButon))
            LeftMouseButtonPressed?.Invoke();

        if(Input.GetMouseButtonDown(RightMouseButon))
            RightMouseButtonPressed?.Invoke();
    }
}
