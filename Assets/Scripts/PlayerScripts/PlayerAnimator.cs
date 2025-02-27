using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private const string MoveSpeed = nameof(MoveSpeed);
    private const string Jump = nameof(Jump);

    [SerializeField] private Animator _animator;

    private readonly int _moveSpeed = Animator.StringToHash(nameof(MoveSpeed));
    private readonly int _jump = Animator.StringToHash(nameof(Jump));

    public void SetMoveAnimation(float value) 
    {
        _animator.SetFloat(_moveSpeed, Mathf.Abs(value));
    }

    public void SetJumpAnimation(bool value) 
    {
        _animator.SetBool(_jump, value);
    }
}
