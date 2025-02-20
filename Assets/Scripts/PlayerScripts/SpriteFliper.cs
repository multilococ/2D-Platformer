using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteFliper : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private readonly string Horizontal = nameof(Horizontal);

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Flip();
    }

    private void Flip()
    {
        if (Input.GetAxisRaw(Horizontal) == 1)
        {
            if (_spriteRenderer.flipX != false)
                _spriteRenderer.flipX = false;
        }
        else if (Input.GetAxisRaw(Horizontal) == -1)
        {
            if (_spriteRenderer.flipX != true)
                _spriteRenderer.flipX = true;
        }
    }
}
