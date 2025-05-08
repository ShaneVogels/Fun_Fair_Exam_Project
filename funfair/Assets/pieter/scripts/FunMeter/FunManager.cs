using UnityEngine;

public class FunManager : MonoBehaviour
{
    public FunMeter funMeter;         // Reference to the FunMeter script
    public FunBoost funBoost;         // Reference to the FunBoost ScriptableObject
    public float maxFun = 100f;       // The maximum fun value allowed

    void Update()
    {
        // Example: Trigger boost when the "B" key is pressed
        if (Input.GetKeyDown(KeyCode.B))
        {
            ApplyFunBoost();
        }
    }

    public void ApplyFunBoost()
    {
        if (funBoost != null && funMeter != null)
        {
            funMeter.fun = funBoost.ApplyBoost(funMeter.fun, maxFun);  // Apply boost to the fun value
        }
    }
}