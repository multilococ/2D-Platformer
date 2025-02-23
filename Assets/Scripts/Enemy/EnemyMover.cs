using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    public void Move(Vector2 target) 
    {
        transform.position = Vector2.MoveTowards(transform.position,target,_speed * Time.deltaTime) ;
    }
}
