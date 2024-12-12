using UnityEngine;

public class BallThrower : MonoBehaviour
{
    public Rigidbody ballRigidbody; // Assign the ball's Rigidbody in the Inspector
    public float maxForce = 1000f;  // Maximum force that can be applied
    public float chargeRate = 200f; // Rate at which the force increases per second
    public KeyCode throwKey = KeyCode.Space; // The key to charge and throw

    private float currentForce = 0f; // Tracks the current charging force
    private bool isCharging = false; // Is the button currently being held?

    void Update()
    {
        // Start charging when the key is pressed
        if (Input.GetKeyDown(throwKey))
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
        if (ballRigidbody != null)
        {
            // Calculate the throw direction (e.g., forward relative to the player)
            Vector3 throwDirection = transform.forward;

            // Apply force to the ball
            ballRigidbody.AddForce(throwDirection * currentForce);
        }
    }
}
