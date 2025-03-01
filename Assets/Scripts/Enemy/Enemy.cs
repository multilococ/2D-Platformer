using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Patrol _patrol;
    [SerializeField] private EnemyAnimator _enemyAnimator;
    [SerializeField] private Fliper _fliper;

    private Vector3 _positionToMove;

    private void Update()
    {
        _patrol.KeepWatching();
        _positionToMove = _patrol.NextPosition;
        _fliper.Flip(_positionToMove.x - transform.position.x);

        if (_patrol.IsMoving == true)
            _enemyAnimator.PlayWalkingAnim();
        else
            _enemyAnimator.PlayWaitingAnim();
    }
}
