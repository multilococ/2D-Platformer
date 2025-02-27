using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Patrol _patrol;
    [SerializeField] private EnemyAnimator _enemyAnimator;

    private SpriteFliper _fliper = new SpriteFliper();

    private Transform _transformToMove;

    private void Update()
    {
        _patrol.KeepWatching();
        _transformToMove = _patrol.NextPosition;
        _fliper.Flip(transform,_transformToMove);

        if (_patrol.IsMoving == true)
        {
            _enemyAnimator.PlayWalkingAnim();
        }
        else
        {
            _enemyAnimator.PlayWaitingAnim();
        }
    }
}
