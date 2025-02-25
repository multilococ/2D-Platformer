using UnityEngine;

public class UserInput : MonoBehaviour
{
    private readonly string Horizontal = nameof(Horizontal);
    private readonly string Jump = nameof(Jump);

    private float _axisX;

    private bool _isJump;

    public float GetAxisX => _axisX;

    public bool IsJump => _isJump;

    private void Update()
    {
        _axisX = Input.GetAxisRaw(Horizontal);
        _isJump = Input.GetButton(Jump);
    }
}
