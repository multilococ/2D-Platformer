using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private EnemyMover _enemyMover;
    [SerializeField] private EnemyAnimationController _enemyAnimationController;
    [SerializeField] private EnemySpriteFliper _enemySpriteFliper;
    [SerializeField] private float _waitingDelay = 2f;

    private WaitForSeconds _waitingTime;

    private int _currentWayPointIndex = 0;

    private float _minDistanceToTarget = 0.1f;

    private Coroutine _coroutine;

    private void Awake()
    {
        _waitingTime = new WaitForSeconds(_waitingDelay); 
    }

    private void Start()
    {
        _enemySpriteFliper.Flip(transform, _wayPoints[_currentWayPointIndex]);
    }

    private void Update()
    {
        MovingWithWaiting();
    }

    private void MovingWithWaiting()
    {
        if (_wayPoints.Length < 1)
        {
            throw new InvalidOperationException();
        }
        else
        {
            if (transform.position.IsEnoughClose(_wayPoints[_currentWayPointIndex].position, _minDistanceToTarget))
            {
                if (_coroutine == null) 
                {
                    _coroutine = StartCoroutine(Stand());
                }
            }
            else 
            {
                _enemyMover.Move(_wayPoints[_currentWayPointIndex].position);   
            }
        }
    }
  
    private IEnumerator Stand() 
    {
        _enemyAnimationController.PlayWaitingAnim();

        yield return _waitingTime;

        _currentWayPointIndex = (_currentWayPointIndex + 1) % _wayPoints.Length;
        _enemySpriteFliper.Flip(transform, _wayPoints[_currentWayPointIndex]);
        _enemyAnimationController.PlayWalkingAnim();
        _coroutine = null;
    }
}
