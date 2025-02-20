using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    [SerializeField] private Transform _target;

    [SerializeField] private float _smoothTimeDelay = 0.2f;

    private Vector3 _cameraPosition;

    private Vector3 _velocity = Vector3.zero;

    private void LateUpdate()
    {
        TranslateCameraSmoothly();
    }

    private void TranslateCameraSmoothly()
    {
        _cameraPosition.x = _target.position.x;
        _cameraPosition.y = _target.position.y;
        _cameraPosition.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, _cameraPosition, ref _velocity, _smoothTimeDelay);
    }
}