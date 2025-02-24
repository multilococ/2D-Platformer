using UnityEngine;

public class UserInput : MonoBehaviour
{
    private readonly string Horizontal = nameof(Horizontal);
    private readonly string Jump = nameof(Jump);

    private float _axisX;

    private bool _isJump = false;

    public bool IsJump => _isJump;

    public float GetAxisX => _axisX;

    private void Update()
    {
        _axisX = Input.GetAxisRaw(Horizontal);

        if (Input.GetButton(Jump))
            _isJump = true;
        else
            _isJump = false;
    }
}
