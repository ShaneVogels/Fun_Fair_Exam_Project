using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    [SerializeField] Movement playerMovement;

    [SerializeField] float sensitivityX;
    [SerializeField] float sensitivityY;
    float mouseX, mouseY;

    [SerializeField] Transform playerCamera;
    [SerializeField] float xClamp = 85f;
    float xRotation = 0f;

    private void Update()
    {
        // Rotate the player horizontally (yaw) based on mouseX
        transform.Rotate(Vector3.up, mouseX * 50 * Time.deltaTime);

        // Calculate and clamp vertical rotation (pitch)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);

        // Apply X and Y rotation to the camera (pitch and yaw)
        Vector3 targetRotation = transform.eulerAngles;
        targetRotation.x = xRotation;

        // Combine the pitch, yaw, and tilt, then assign to camera
        playerCamera.rotation = Quaternion.Euler(targetRotation);
    }

    public void ReciveInput(InputAction.CallbackContext context)
    {
        Vector2 mouseInput = context.ReadValue<Vector2>();
        mouseX = mouseInput.x * sensitivityX;
        mouseY = mouseInput.y * sensitivityY;
    }
}
