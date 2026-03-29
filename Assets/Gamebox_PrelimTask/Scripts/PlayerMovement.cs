using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 5f;
    [SerializeField] private Transform _mainCameraTransform;
    private Vector3 _movementVector;

    void Update()
    {
        TurnCharacter();
        transform.Translate(_movementVector * _playerSpeed * Time.deltaTime);        
    }
    public void MoveCharacter(InputAction.CallbackContext context)
    {
        if (!context.started)
        {
            Vector2 _movementInput = context.ReadValue<Vector2>();            
            _movementVector = new Vector3(_movementInput.x, 0f, _movementInput.y);
        }
    }
    private void TurnCharacter()
    {
        Vector3 cameraForward = _mainCameraTransform.forward;
        Vector3 cameraRight = _mainCameraTransform.right;
        cameraForward.y = 0f;
        cameraRight.y = 0f;

        cameraForward.Normalize();
        cameraRight.Normalize();

        Quaternion lookDirection = Quaternion.LookRotation(cameraForward, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection, _rotationSpeed * Time.deltaTime);
    }
}
