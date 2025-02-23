using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private UserInput _userInput;
    [SerializeField] private Player _player;
    [SerializeField] private GroundChecker _groundChecker;

    [SerializeField] private float _jumpForce = 10f;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = _player.GetRigidbody;
    }

    private void OnEnable()
    {
        _userInput.PressedSpace += MakeJamp;
    }

    private void OnDisable()
    {
        _userInput.PressedSpace -= MakeJamp;
    }

    private void MakeJamp()
    {
        if (_groundChecker.IsGrounded)
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}
