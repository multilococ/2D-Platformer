using UnityEngine;

public class Fliper
{
    private float _turn = -180;

    public void Flip(Transform flipTransform, float direction)
    {
        Vector3 rotation = flipTransform.rotation.eulerAngles;

        if (direction > 0)
            rotation.y = 0;
        else
            rotation.y = _turn;

        flipTransform.rotation = Quaternion.Euler(rotation);
    }

    public void Flip(Transform flipedTransform, Transform nextTransform)
    {
        Vector3 rotation = flipedTransform.rotation.eulerAngles;

        if (flipedTransform.position.x < nextTransform.position.x)
            rotation.y = 0;
        else
            rotation.y = _turn;

        flipedTransform.rotation = Quaternion.Euler(rotation);
    }
}