using UnityEngine;

public class SpriteFliper
{
    private float _leftSide = 1;
    private float _rightSide = -1;

    public void Flip(Transform flipTransform, float turn)
    {
        Vector3 scale = flipTransform.localScale;

        if (turn > _leftSide || turn == 0)
            turn = _leftSide;
        else if (turn < _rightSide)
            turn -= _rightSide;

        scale.x = turn;
        flipTransform.localScale = scale;
    }

    public void Flip(Transform flipedTransform, Transform nextTransform)
    {
        Vector3 scale = flipedTransform.localScale;

        if (flipedTransform.position.x < nextTransform.position.x)
            scale.x = _leftSide;
        else
            scale.x = _rightSide;

        flipedTransform.localScale = scale;
    }
}
