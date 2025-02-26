using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Patrol _patrol;
    [SerializeField] private EnemyAnimator _enemyAnimator;

    private SpriteFliper _fliper = new SpriteFliper();

    private Transform _transformToMove;

    private float _leftSide = 1;
    private float _rightSide = -1;

    private void Update()
    {
        _patrol.MovingWithWaiting();

        _transformToMove = _patrol.NextPosition;

        if (transform.position.x < _transformToMove.position.x)
            _fliper.Flip(transform,_leftSide);
        else 
            _fliper.Flip(transform, _rightSide);

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
