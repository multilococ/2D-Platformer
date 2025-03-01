using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private UserInput _userInput;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private Fliper _fliper;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _fliper.SetDirection(transform.localScale.x);
    }

    private void OnEnable()
    {
        _userInput.SpacePresed += MakeJump;
    }

    private void OnDisable()
    {
        _userInput.SpacePresed -= MakeJump;
    }

    private void FixedUpdate()
    {
        if (_userInput.AxisX != 0)
        {
            _playerMover.Move(_rigidbody2D, _userInput.AxisX);
            _fliper.Flip(_userInput.AxisX);
        }

        if (_groundChecker.IsGrounded == true)
            _playerAnimator.SetMoveAnimation(_userInput.AxisX);

            _playerAnimator.SetJumpAnimation(_groundChecker.IsGrounded != true);
    }

    private void MakeJump() 
    {
        if (_groundChecker.IsGrounded)
            _jumper.MakeJump(_rigidbody2D);
    }
}
