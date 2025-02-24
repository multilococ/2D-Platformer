using UnityEngine;

public class SpriteFliper 
{
    public void Flip(Transform transform) 
    {
        Vector3 scale = transform.localScale;

        scale.x *= -1f;
        transform.localScale = scale;
    }
}
