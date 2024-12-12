using UnityEngine;

[System.Serializable] // Make it appear in inspector
public class InventoryItem 
{
    public string itemName;
    public bool isEnabled;
    public GameObject itemPrefab;
}
