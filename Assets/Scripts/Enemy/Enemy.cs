using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Patrol _patrol;
    [SerializeField] private EnemyAnimationController _animationController;

    private SpriteFliper _fliper = new SpriteFliper();

    private bool _fliped = true;

    private void Update()
    {
        _patrol.MovingWithWaiting();

        if (_patrol.IsMoving == true)
        {
            _animationController.PlayWalkingAnim();

            if (_fliped == false)
            {
                _fliped = true;
                _fliper.Flip(transform);
            }
        }
        else
        {
            _animationController.PlayWaitingAnim();
            _fliped = false;
        }
    }
}
