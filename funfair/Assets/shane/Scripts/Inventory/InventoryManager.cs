using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private Inventory playerInventory;
    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField] private InventoryItem inventoryItem;   

    // Add prize to inventory
    public void WinPrize(string prizeName)
    {
        playerInventory.EnableItem(prizeName);
        Debug.Log($"{prizeName} added to inventory!");
        inventoryUI.UpdateUI();
    }

    // Check if item is in inventory
    public bool HasItem(string itemName)
    {
        return playerInventory.IsItemEnabled(itemName);
    }
    
}
