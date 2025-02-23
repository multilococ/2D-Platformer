using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    private readonly string isStanding = nameof(isStanding);

    [SerializeField] private Animator _animator;

    public void PlayWaitingAnim() 
    {
        _animator.SetBool(isStanding, true);
    }

    public void PlayWalkingAnim() 
    {
        _animator.SetBool(isStanding, false);
    }
}
