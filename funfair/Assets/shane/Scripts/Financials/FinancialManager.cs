using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinancialManager : MonoBehaviour
{
    public static FinancialManager Instance { get; private set; }

    [SerializeField]private int currentMoney;
    public TextMeshProUGUI MoneyText; // Reference to TextMeshPro UI component

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        
        DontDestroyOnLoad(gameObject); // Persist across scenes
        ResetMoney(); // Reset Money on game start
    }

    // Add Money
    public void AddMoney(int amount)
    {
        currentMoney += amount;
        UpdateMoneyUI();
        Debug.Log($"Money added: {amount}. Total: {currentMoney}");
    }

    // Subtract Money
    public bool SpendMoney(int amount)
    {
        if (currentMoney >= amount)
        {
            currentMoney -= amount;
            UpdateMoneyUI();
            Debug.Log($"Money spent: {amount}. Remaining: {currentMoney}");
            return true; // Purchase successful
        }

        Debug.Log("Not enough Money!");
        return false; // Purchase failed
    }

    // Get current Money
    public int GetMoney()
    {
        return currentMoney;
    }

    // Reset Money
    private void ResetMoney()
    {
        currentMoney = 0; // Default to 0 on game start
        UpdateMoneyUI();
        Debug.Log("Money reset to 0.");
    }

    // Update TextMeshPro UI with current Money value
    private void UpdateMoneyUI()
    {
        if (MoneyText != null)
        {
            MoneyText.text = $"{currentMoney}";
        }
    }
}
