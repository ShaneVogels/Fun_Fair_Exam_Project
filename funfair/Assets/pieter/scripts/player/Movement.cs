using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    [SerializeField] MouseLook mouseLook;

    // Movement
    private Vector2 movementInput = Vector2.zero;
    Vector3 move;
    private CharacterController controller;

    // Sprint
    [SerializeField] float sprintSpeedMultiplier = 2f;
    [SerializeField] int maxStamina = 100;
    [SerializeField] float sprintStaminaCostPerSecond = 10f;
    [SerializeField] float staminaRegenPerSecond = 5f;
    [SerializeField] float playerSpeed = 2.0f;
    private bool sprinting = false;
    private float stamina;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
        stamina = maxStamina;
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    public void OnSprint(InputAction.CallbackContext context)
    {
        sprinting = context.action.triggered && stamina >= sprintStaminaCostPerSecond * Time.deltaTime;
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        float currentSpeed = playerSpeed;

        // Handle sprinting
        if (sprinting && stamina >= sprintStaminaCostPerSecond * Time.deltaTime)
        {
            currentSpeed *= sprintSpeedMultiplier;
            stamina -= sprintStaminaCostPerSecond * Time.deltaTime; // Decrease based on time
        }
        else
        {
            stamina += staminaRegenPerSecond * Time.deltaTime;
            stamina = Mathf.Clamp(stamina, 0, maxStamina); // Ensure stamina doesn't exceed max
        }

        // Movement based on player input
        move = (transform.right * movementInput.x + transform.forward * movementInput.y);
        controller.Move(move * Time.deltaTime * currentSpeed);
    }
}