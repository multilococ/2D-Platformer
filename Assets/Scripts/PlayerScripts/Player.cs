using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private UserInput _userInput;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private PlayerAnimationController _playerAnimationController;

    private SpriteFliper _spriteFliper = new SpriteFliper();

    private Rigidbody2D _rigidbody2D;

    private float _currentDirection;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _currentDirection = transform.localScale.x;
    }

    private void FixedUpdate()
    {
        if (_userInput.GetAxisX != 0 && _userInput.GetAxisX != _currentDirection)
        {
            _currentDirection = _userInput.GetAxisX;
            _spriteFliper.Flip(transform);
        }

        if (_userInput.GetAxisX != 0)
            _currentDirection = _userInput.GetAxisX;

        if (_userInput.GetAxisX != 0)
            _playerMover.Move(_rigidbody2D, _userInput.GetAxisX);

        if (_userInput.IsJump && _groundChecker.IsGrounded)
            _jumper.MakeJamp(_rigidbody2D);

        if (_groundChecker.IsGrounded == true)
            _playerAnimationController.SetMoveAnimation(_userInput.GetAxisX);

            _playerAnimationController.SetJumpAnimation(_groundChecker.IsGrounded != true);
    }
}
