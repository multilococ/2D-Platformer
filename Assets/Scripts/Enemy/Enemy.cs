using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Patrol _patrol;
    [SerializeField] private EnemyAnimator _enemyAnimator;
    [SerializeField] private Fliper _fliper;

    private float _leftDirecion = -1;
    private float _rightDirecion = 1;

    private Vector3 _positionToMove;

    private void Update()
    {
        _patrol.KeepWatching();
        _positionToMove = _patrol.NextPosition;

        if (_positionToMove.x > transform.position.x)
            _fliper.Flip(_rightDirecion);
        else
            _fliper.Flip(_leftDirecion);

        if (_patrol.IsMoving == true)
            _enemyAnimator.PlayWalkingAnim();
        else
            _enemyAnimator.PlayWaitingAnim();
    }
}
