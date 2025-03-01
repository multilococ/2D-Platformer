using System;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    private readonly string Horizontal = nameof(Horizontal);
    private readonly string Jump = nameof(Jump);

    public float AxisX { get; private set; }

    public event Action SpacePresed;

    private void Update()
    {
        AxisX = Input.GetAxisRaw(Horizontal);

        if (Input.GetButtonDown(Jump))
         SpacePresed?.Invoke();
    }
}
