using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Game Data/Inventory")]
public class Inventory : ScriptableObject
{
    public List<InventoryItem> items;

    // Enable an item by name
    public void EnableItem(string itemName)
    {
        foreach (var item in items)
        {
            if (item.itemName == itemName)
            {
                item.isEnabled = true;
                return;
            }
        }
    }

    // Disable an item by name
    public void DisableItem(string itemName)
    {
        foreach (var item in items)
        {
            if (item.itemName == itemName)
            {
                item.isEnabled = false;
                return;
            }
        }
    }

    // Check if an item is enabled
    public bool IsItemEnabled(string itemName)
    {
        foreach (var item in items)
        {
            if (item.itemName == itemName)
            {
                return item.isEnabled;
            }
        }
        return false;
    }
}
