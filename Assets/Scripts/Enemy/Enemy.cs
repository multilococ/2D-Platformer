using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Patrol _patrol;
    [SerializeField] private EnemyAnimator _enemyAnimator;
    [SerializeField] private Fliper _fliper;
    [SerializeField] private PlayerSearcher _playerSearcher;
    [SerializeField] private EnemyMover _enemyMover;
    [SerializeField] private EnemyAttacker _enemyAttacker;

    private float _leftDirecion = -1;
    private float _rightDirecion = 1;
    private float _minDistanceToAttack = 1.5f;

    private Vector3 _positionToMove;

    private void Update()
    {
        if (_playerSearcher.Target == null)
        {
            _patrol.KeepWatching();
            _positionToMove = _patrol.NextPosition;

            if (_patrol.IsMoving == true)
                _enemyAnimator.PlayWalkingAnimation();
            else
                _enemyAnimator.PlayWaitingAnimation();
        }
        else 
        {
            _positionToMove = _playerSearcher.Target.position;

            if (transform.position.IsEnoughClose(_positionToMove, _minDistanceToAttack))
            {
                if (_enemyAttacker.CanAttack == true)
                {
                    _enemyAttacker.MakeAttack(_playerSearcher.Target);
                }
                else 
                {
                    _enemyAnimator.PlayWaitingAnimation();
                }
            }
            else
            {
                _enemyMover.Move(new Vector2(_positionToMove.x, transform.position.y));
                _enemyAnimator.PlayWalkingAnimation();
            }
        }

        if (_positionToMove.x > transform.position.x)
            _fliper.Flip(_rightDirecion);
        else
            _fliper.Flip(_leftDirecion);
    }
}
