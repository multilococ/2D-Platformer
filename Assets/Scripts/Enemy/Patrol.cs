using System;
using System.Collections;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private EnemyMover _enemyMover;

    [SerializeField] private float _waitingDelay = 2f;

    private WaitForSeconds _waitingTime;
    private Transform _nextPosition;
    private Coroutine _coroutine;

    private int _currentWayPointIndex = 0;

    private float _minDistanceToTarget = 0.1f;

    public Transform NextPosition => _nextPosition;

    public bool IsMoving { private set; get; }

    private void Awake()
    {
        _waitingTime = new WaitForSeconds(_waitingDelay);
        _nextPosition = _wayPoints[_currentWayPointIndex];

        if (_wayPoints.Length < 1)
        {
            throw new InvalidOperationException();
        }
    }

    public void MovingWithWaiting()
    {
        if (transform.position.IsEnoughClose(_wayPoints[_currentWayPointIndex].position, _minDistanceToTarget))
        {
            IsMoving = false;

            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(Stand());
            }
        }
        else
        {
            IsMoving = true;
            _enemyMover.Move(_wayPoints[_currentWayPointIndex].position);
        }
    }

    private IEnumerator Stand()
    {
        yield return _waitingTime;

        _currentWayPointIndex = ++_currentWayPointIndex % _wayPoints.Length;
        _nextPosition = _wayPoints[_currentWayPointIndex];
        _coroutine = null;
    }
}
