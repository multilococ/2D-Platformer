using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemySpriteFliper : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Flip(Transform currentPosition,Transform nextPosition) 
    {
        _spriteRenderer.flipX = currentPosition.position.x > nextPosition.position.x;
    }
}
