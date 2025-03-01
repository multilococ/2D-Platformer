using UnityEngine;

public class Fliper : MonoBehaviour 
{
    private float _leftTurn = -180;
    private float _rightTurn = 0;
    private float _leftDirection = -1;
    private float _rightDirection = 1;
    private float _currentDirection = 1;

    public void SetDirection(float direction) 
    {
        if (direction > _rightDirection)
            direction = _rightDirection;
        else if (direction < _leftDirection)
            direction = -_leftDirection;
        else 
            direction = _rightDirection;

        _currentDirection = direction;
    }

    public void Flip(float direction)
    {
        Vector3 rotation = transform.rotation.eulerAngles;

        if (_currentDirection != direction)
        {
            if (direction > 0)
            {
                direction = _rightDirection;
                rotation.y = _rightTurn;
            }
            else
            {
                direction = _leftDirection;
                rotation.y = _leftTurn;
            }

            _currentDirection = direction;
            transform.rotation = Quaternion.Euler(rotation);
        }
    }
}