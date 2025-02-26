using UnityEngine;

public class SpriteFliper
{
    private float _upperLimit = 1;
    private float _lowerLimit = -1;

    public void Flip(Transform transform, float turn)
    {
        Vector3 scale = transform.localScale;

        if (turn > _upperLimit || turn == 0)
            turn = 1;
        else if (turn < _lowerLimit)
            turn -= 1;

        scale.x = turn;
        transform.localScale = scale;
    }
}
