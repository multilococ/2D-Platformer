using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private UserInput _userInput;

    private readonly string MoveSpeed = nameof(MoveSpeed);
    private readonly string Jump = nameof(Jump);

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_groundChecker.IsGrounded == true)
            _animator.SetFloat(MoveSpeed, Mathf.Abs(_userInput.GetAxisX));
        
        if(_groundChecker.IsGrounded == false)
            _animator.SetBool(Jump,true);
        else
            _animator.SetBool(Jump,false);
    }
}
