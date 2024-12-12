using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunMeter : MonoBehaviour
{
    public float fun = 1f;  // The value that will decrease over time
    public float currentFun;  // The current value you want to track
    float decreaseRate = 0.1f;

    void Update()
    {
        fun -= decreaseRate * Time.deltaTime;  // Decrease fun over time
        currentFun = fun;  // Update currentFun to match the updated value of fun

        Debug.Log(fun);  // Log the current value of fun
    }
}
