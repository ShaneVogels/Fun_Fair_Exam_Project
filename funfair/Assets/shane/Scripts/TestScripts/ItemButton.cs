using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

// TEST SCRIPT MADE BY AI FOR TIMESAVINGS

public class ItemButton : MonoBehaviour
{
    public Inventory playerInventory;       // Reference to the Inventory script
    public InventoryUI inventoryUI;  // Reference to the InventoryUI script
    public InventoryManager invManager; // Reference to the InventoryManager script

    void Start()
    {
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
        invManager.WinPrize("Popcorn");
        invManager.WinPrize("Hotdog");
        invManager.WinPrize("CottonCandy");

        /* Popcorn directly
         * 
        // Find the Popcorn item in the inventory
        InventoryItem popcornItem = playerInventory.items.Find(item => item.itemName == "Popcorn");

        if (popcornItem != null)
        {
            // Enable the Popcorn item
            popcornItem.isEnabled = true;

            // Output debug log for testing
            Debug.Log($"Item '{popcornItem.itemName}' is now enabled!");

            // Update the UI after enabling the item
            inventoryUI.UpdateUI();
        }
        else
        {
            Debug.LogWarning("Popcorn item not found in the inventory.");
        }
        */
    }
}
