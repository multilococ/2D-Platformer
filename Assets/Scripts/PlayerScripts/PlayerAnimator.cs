using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private const string MoveSpeed = nameof(MoveSpeed);
    private const string Jump = nameof(Jump);
    private const string Attack = nameof(Attack);
    private const string AttackAnimation = nameof(AttackAnimation);

    private Animator _animator;

    private readonly int _moveSpeed = Animator.StringToHash(nameof(MoveSpeed));
    private readonly int _jump = Animator.StringToHash(nameof(Jump));
    private readonly int _attack = Animator.StringToHash(nameof(Attack));

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetMoveAnimation(float value)
    {
        _animator.SetFloat(_moveSpeed, Mathf.Abs(value));
    }

    public void SetJumpAnimation(bool value)
    {
        _animator.SetBool(_jump, value);
    }

    public void PlayAttackAnimation()
    {
        _animator.SetTrigger(_attack);
    }

    public bool GetStateOfAttackAnimation()
    {
        AnimatorStateInfo animationStateInfo = _animator.GetCurrentAnimatorStateInfo(0);

        return animationStateInfo.IsName(AttackAnimation);
    }
}
