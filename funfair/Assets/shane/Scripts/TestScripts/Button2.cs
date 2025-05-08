using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button2 : MonoBehaviour
{
    public Inventory playerInventory;       // Reference to the Inventory script
    public InventoryUI inventoryUI;         // Reference to the InventoryUI script
    public InventoryManager invManager;     // Reference to the InventoryManager script   
    public FinancialManager financialManager; // Reference to the FinancialManager script

    void Start()
    {
        // Check if the FinancialManager is assigned; if not, search for it
        if (financialManager == null)
        {
            // Finds FinancialManager in script and assigns it (works for inv manager as well)
            financialManager = FindObjectOfType<FinancialManager>();
            if (financialManager == null)
            {
                Debug.LogError("FinancialManager not found in the scene!");
            }
        }

        if (invManager == null)
            Debug.LogError("InventoryManager reference is missing!");
        if (playerInventory == null)
            Debug.LogError("PlayerInventory reference is missing!");
        if (inventoryUI == null)
            Debug.LogError("InventoryUI reference is missing!");

        // Attach a listener to the button (assuming button is on the same GameObject)
        Button button = GetComponent<Button>();  // Keep using Button
        button.onClick.AddListener(OnAddItemButtonClick);
    }

    void OnAddItemButtonClick()
    {
        if (SceneManager.GetActiveScene().name == "TestSceneShane")
        {
            SceneManager.LoadScene("shane");
            inventoryUI.UpdateUI();
            Debug.Log("Loading scene Shane");
        }
        else
        {
            if (financialManager != null)
            {
                // Removes money
                financialManager.SpendMoney(10);
                inventoryUI.UpdateUI();
                Debug.Log("Spending Money");
            }
            else
            {
                Debug.LogError("Cannot spend money because FinancialManager is not assigned or found!");
            }
        }
    }
}
