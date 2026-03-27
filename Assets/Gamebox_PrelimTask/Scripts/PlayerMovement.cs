using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 5f;
    [SerializeField] private Transform _mainCameraTransform;
    private Vector3 _movementVector;

    void Update()
    {
        transform.Translate(_movementVector * _playerSpeed * Time.deltaTime);

    }
    public void MovePlayer(InputAction.CallbackContext context)
    {
        if (!context.started)
        {
            var _movementDirection = context.ReadValue<Vector2>();

            Vector3 cameraForward = _mainCameraTransform.forward;
            Vector3 cameraRight = _mainCameraTransform.right;
            cameraForward.y = 0f;
            cameraRight.y = 0f;
            cameraForward.Normalize();

            _movementVector = cameraRight * _movementDirection.x + cameraForward * _movementDirection.y;
            transform.forward = cameraForward;
        }
    }
}
