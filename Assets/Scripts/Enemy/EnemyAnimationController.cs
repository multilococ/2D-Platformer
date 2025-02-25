using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private readonly int isStanding = Animator.StringToHash(nameof(isStanding));

    public void PlayWaitingAnim() 
    {
        _animator.SetBool(isStanding, true);
    }

    public void PlayWalkingAnim() 
    {
        _animator.SetBool(isStanding, false);
    }
}
