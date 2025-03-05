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
    [SerializeField] private Combat _combat;
    [SerializeField] private Health _healt;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _userInput.SpacePresed += MakeJump;
        _userInput.LeftMouseButtonPressed += MakeAttack;
    }

    private void OnDisable()
    {
        _userInput.SpacePresed -= MakeJump;
        _userInput.LeftMouseButtonPressed -= MakeAttack;
    }

    private void FixedUpdate()
    {
        if (!_playerAnimator.GetStateOfAttackAnimation())
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
    }

    private void MakeAttack()
    {
        if (_groundChecker.IsGrounded && _combat.CanAttack)
        {
            _combat.Attack();
            _playerAnimator.PlayAttackAnimation();
        }
    }

    private void MakeJump()
    {
        if (_groundChecker.IsGrounded && !_playerAnimator.GetStateOfAttackAnimation())
            _jumper.MakeJump(_rigidbody2D);
    }
}
