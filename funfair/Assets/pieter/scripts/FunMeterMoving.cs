using UnityEngine;
using UnityEngine.UI;

public class FunMeterMoving : MonoBehaviour
{
    public Slider slider;  // Reference to the Slider component

    // This will be called to update the slider's value
    public void SetFun(int currentFun)
    {
        slider.maxValue = 100;  // Set max value of the slider
        slider.value = currentFun;  // Set the current value
    }
}