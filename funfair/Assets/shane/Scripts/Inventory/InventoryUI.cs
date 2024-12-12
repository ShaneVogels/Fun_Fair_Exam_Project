using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Inventory playerInventory; // Reference to Inventory ScriptableObject
    [SerializeField] private Transform inventoryPanel; // Parent object for inventory items
    [SerializeField] private GameObject invUI;
    [SerializeField] private GameObject statsUI;

    private GameObject itemPrefab; // UI prefab for displaying items (PLACE CHILD IMG IN PANEL AND ASSIGN SPRITE (IMG > SPRITE 2D/UI))

    void Start()
    {
        // Updates UI
        UpdateUI();
    }

    public void UpdateUI()
    {
        // Clear existing items
        foreach (Transform child in inventoryPanel)
        {
            Destroy(child.gameObject);
        }

        // Add enabled items
        foreach (var item in playerInventory.items)
        {
            if (item.isEnabled)
            {
                // Instantiate the prefab associated with item
                GameObject newItem = Instantiate(item.itemPrefab, inventoryPanel);

                // Optionally, you can add UI elements here (such as item name) if necessary
                // For example, setting item name in a UI text element
                // newItem.GetComponentInChildren<Text>().text = item.itemName;
            }
        }

        Debug.Log("Updating Inventory UI");

    }

    public void OpenInv()
    {
        Debug.Log("Opening Inventory");

        if (invUI.activeSelf)
        {
            UpdateUI();
        }
        else
        {
            statsUI.SetActive(false);
            invUI.SetActive(true);
            UpdateUI();
        }        
    }
    
    public void OpenStats()
    {
        Debug.Log("Opening Statistics");

        if (statsUI.activeSelf)
        {
            UpdateUI();
        }
        else
        {
            invUI.SetActive(false);
            statsUI.SetActive(true);
            UpdateUI();
        }        
    }

    public void QuitGame()
    {
        Debug.Log("Quitting the game");
        Application.Quit();
    }
}
