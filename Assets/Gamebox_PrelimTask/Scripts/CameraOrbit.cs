using UnityEngine;
using UnityEngine.InputSystem;

public class CameraOrbit : MonoBehaviour
{
    [SerializeField] private float _turnSpeed = 5f;
    [SerializeField] private float _CamRotationRadius = 10f;
    [SerializeField] private Transform _playerTransform;
    private Vector2 _camLookDirection;
    private Vector3 _cameraStartingRotation;


    void Awake()
    {
        _cameraStartingRotation = transform.rotation.eulerAngles;
        _camLookDirection = new Vector2(_cameraStartingRotation.x, _cameraStartingRotation.y);
    }

    private void LateUpdate()
    {
        Quaternion cameraRotation = Quaternion.Euler(_camLookDirection.x, _camLookDirection.y, 0f);
        Vector3 cameraLookDirection = cameraRotation * Vector3.forward;
        
        Vector3 offset = cameraLookDirection * _CamRotationRadius;
        Vector3 cameraPosition = _playerTransform.position - offset;
        
        //Debug.Log($"{cameraRotation} * {Vector3.forward} = {cameraLookDirection}");
        transform.SetPositionAndRotation(cameraPosition, cameraRotation);
    }
    public void LookAround(InputAction.CallbackContext context)
    {
        Vector2 lookDirectionInput = context.ReadValue<Vector2>();
        float deltaX = lookDirectionInput.x;
        _camLookDirection.y += deltaX * _turnSpeed * Time.unscaledDeltaTime;
        _camLookDirection.y = Mathf.Repeat(_camLookDirection.y, 360f);
    }
}
