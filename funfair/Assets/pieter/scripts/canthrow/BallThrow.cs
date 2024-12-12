using UnityEngine;

public class BallThrow : MonoBehaviour
{
    public GameObject ballPrefab;    // Prefab of the ball
    public Transform throwOrigin;   // Position where the ball spawns
    public float maxForce = 1000f;  // Maximum force that can be applied
    public float chargeRate = 200f; // Rate at which the force increases per second
    public KeyCode throwKey = KeyCode.Space; // The key to charge and throw

    private float currentForce = 0f; // Tracks the current charging force
    private bool isCharging = false; // Is the button currently being held?
    private int remainingThrows = 3; // Limit of 3 throws

    void Update()
    {
        // Start charging when the key is pressed and throws remain
        if (remainingThrows > 0 && Input.GetKeyDown(throwKey))
        {
            isCharging = true;
            currentForce = 0f; // Reset the force when starting a new charge
        }

        // While holding the key, increase the charge
        if (isCharging && Input.GetKey(throwKey))
        {
            currentForce += chargeRate * Time.deltaTime;
            currentForce = Mathf.Clamp(currentForce, 0f, maxForce); // Cap the force to maxForce
        }

        // Release the key to throw the ball
        if (isCharging && Input.GetKeyUp(throwKey))
        {
            ThrowBall();
            isCharging = false; // Reset charging state
        }
    }

    private void ThrowBall()
    {
        if (remainingThrows > 0 && ballPrefab != null && throwOrigin != null)
        {
            // Instantiate the ball at the throw origin
            GameObject ballInstance = Instantiate(ballPrefab, throwOrigin.position, throwOrigin.rotation);

            // Apply force to the ball's Rigidbody
            Rigidbody ballRigidbody = ballInstance.GetComponent<Rigidbody>();
            if (ballRigidbody != null)
            {
                Vector3 throwDirection = throwOrigin.forward; // Direction relative to throw origin
                ballRigidbody.AddForce(throwDirection * currentForce, ForceMode.Impulse); // Apply force as an impulse
            }

            // Reduce the remaining throws
            remainingThrows--;
        }
    }
}
