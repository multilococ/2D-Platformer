using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private readonly int MoveSpeed = Animator.StringToHash(nameof(MoveSpeed));
    private readonly int Jump = Animator.StringToHash(nameof(Jump));

    public void SetMoveAnimation(float value) 
    {
        _animator.SetFloat(MoveSpeed, Mathf.Abs(value));
    }

    public void SetJumpAnimation(bool value) 
    {
        _animator.SetBool(Jump, value);
    }
}
