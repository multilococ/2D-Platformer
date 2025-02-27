using UnityEngine;

public class Fliper
{
    private float _leftTurn = -180;
    private float _rightTurn = 0;

    public void Flip(Transform flipTransform, float direction)
    {
        Vector3 rotation = flipTransform.rotation.eulerAngles;

        if (direction > 0)
            rotation.y = _rightTurn;
        else
            rotation.y = _leftTurn;

        flipTransform.rotation = Quaternion.Euler(rotation);
    }

    public void Flip(Transform flipedTransform, Transform nextTransform)
    {
        Vector3 rotation = flipedTransform.rotation.eulerAngles;

        if (flipedTransform.position.x < nextTransform.position.x)
            rotation.y = _rightTurn;
        else
            rotation.y = _leftTurn;

        flipedTransform.rotation = Quaternion.Euler(rotation);
    }
}