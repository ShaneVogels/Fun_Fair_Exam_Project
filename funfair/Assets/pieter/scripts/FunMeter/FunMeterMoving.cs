using UnityEngine;
using UnityEngine.UI;

public class FunMeterMoving : MonoBehaviour
{
    public Slider slider;  // Reference to the Slider component

    void Start()
    {
        slider.maxValue = 100;  // Set the max value of the slider
    }

    // Update the slider's value dynamically
    public void SetFun(int currentFun)
    {
        slider.value = currentFun;
    }
}
