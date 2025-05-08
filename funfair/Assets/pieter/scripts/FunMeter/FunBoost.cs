using UnityEngine;

[CreateAssetMenu(fileName = "NewFunBoost", menuName = "ScriptableObjects/FunBoost")]
public class FunBoost : ScriptableObject
{
    public float boostAmount = 10f;  // The amount of fun to add

    // Apply the boost to the current fun value
    public float ApplyBoost(float currentFun, float maxFun)
    {
        return Mathf.Clamp(currentFun + boostAmount, 0, maxFun);  // Ensure it stays within bounds
    }
}
