using UnityEngine;

public class FunMeter : MonoBehaviour
{
    public float fun = 100f;  // Start with a value of 100
    public float currentFun;  // Current value
    [SerializeField] float decreaseRate;

    public FunMeterMoving funMeterUI;  // Reference to the UI FunMeterMoving script

    void Update()
    {
        // Decrease fun over time
        fun -= decreaseRate * Time.deltaTime;
        currentFun = fun;

        // Update the UI slider with the current fun value
        if (funMeterUI != null)
        {
            funMeterUI.SetFun((int)currentFun);  // Convert to int for the slider
        }
    }
}
