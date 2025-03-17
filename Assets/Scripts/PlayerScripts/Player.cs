using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private UserService _userService;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private Fliper _fliper;
    [SerializeField] private Combat _combat;
    [SerializeField] private VampirismAbility _vampirismAbility;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _userService.SpacePresed += MakeJump;
        _userService.LeftMouseButtonPressed += MakeAttack;
        _userService.RightMouseButtonPressed += _vampirismAbility.Use;
    }

    private void OnDisable()
    {
        _userService.SpacePresed -= MakeJump;
        _userService.LeftMouseButtonPressed -= MakeAttack;
        _userService.RightMouseButtonPressed -= _vampirismAbility.Use;
    }

    private void FixedUpdate()
    {
        if (!_playerAnimator.GetStateOfAttackAnimation())
        {
            if (_userService.AxisX != 0)
            {
                _playerMover.Move(_rigidbody2D, _userService.AxisX);
                _fliper.Flip(_userService.AxisX);
            }

            if (_groundChecker.IsGrounded == true)
                _playerAnimator.SetMoveAnimation(_userService.AxisX);

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
