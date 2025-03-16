using UnityEngine;

public class SmoothTracker : MonoBehaviour
{
    [SerializeField] private Transform _target;

    [SerializeField] private float _smoothTimeDelay = 0.2f;

    private Vector3 _trackerPosition;

    private Vector3 _velocity = Vector3.zero;

    private void LateUpdate()
    {
        TranslateCameraSmoothly();
    }

    private void TranslateCameraSmoothly()
    {
        _trackerPosition.x = _target.position.x;
        _trackerPosition.y = _target.position.y;
        _trackerPosition.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, _trackerPosition, ref _velocity, _smoothTimeDelay);
    }
}