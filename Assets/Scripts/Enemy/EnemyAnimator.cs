using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private const string IsStanding = nameof (IsStanding);

    [SerializeField] private Animator _animator;
 
    private readonly int _isStanding = Animator.StringToHash(nameof(IsStanding));

    public void PlayWaitingAnimation() 
    {
        _animator.SetBool(_isStanding, true);
    }

    public void PlayWalkingAnimation() 
    {
        _animator.SetBool(_isStanding, false);
    }
}
