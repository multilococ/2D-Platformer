using System;
using System.Collections;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private EnemyMover _enemyMover;

    [SerializeField] private float _waitingDelay = 2f;

    private WaitForSeconds _waitingTime;
    private Coroutine _coroutine;

    private int _currentWayPointIndex = 0;

    private float _minDistanceToTarget = 0.1f;

    public Vector3 NextPosition { get; private set; }

    public bool IsMoving { get; private set; }

    private void Awake()
    {
        _waitingTime = new WaitForSeconds(_waitingDelay);
        NextPosition = _wayPoints[_currentWayPointIndex].position;

        if (_wayPoints.Length < 1)
        {
            throw new InvalidOperationException();
        }
    }

    public void KeepWatching()
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
        NextPosition = _wayPoints[_currentWayPointIndex].position;
        _coroutine = null;
    }
}
