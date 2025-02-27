using UnityEngine;

public class UserInput : MonoBehaviour
{
    private readonly string Horizontal = nameof(Horizontal);
    private readonly string Jump = nameof(Jump);

    private float _axisX;

    public float AxisX => _axisX;

    public bool IsJump { get; private set; }

    private void Update()
    {
        _axisX = Input.GetAxisRaw(Horizontal);
        IsJump = Input.GetButtonDown(Jump);
    }
}
