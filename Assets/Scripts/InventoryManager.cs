using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    //singleton
    private static InventoryManager _instance;
    public static InventoryManager Instance => _instance;
    
    public Dictionary<MaterialType, int> inventory = new Dictionary<MaterialType, int>();
    
    
    
    


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    void Update()
    {
        //TODO: remove this later
        if (Input.GetKeyDown(KeyCode.B))
        {
            PrintInventory();
        }
    }
    
    public void AddItem(MaterialType materialType, int amount)
    {
        if (inventory.ContainsKey(materialType))
        {
            inventory[materialType] += amount;
        }
        else
        {
            inventory.Add(materialType, amount);
        }
    }
    
    public void RemoveItem(MaterialType materialType, int amount)
    {
        if (inventory.ContainsKey(materialType))
        {
            inventory[materialType] -= amount;
        }
        else
        {
            Debug.LogError("Inventory does not contain this item");
        }
    }
    
    public bool HasEnoughItem(MaterialType materialType, int amount)
    {
        if (inventory.ContainsKey(materialType))
        {
            return inventory[materialType] >= amount;
        }
        else
        {
            return false;
        }
    }
    
    public void PrintInventory()
    {
        foreach (var item in inventory)
        {
            Debug.Log(item.Key + " : " + item.Value);
        }
    }
    
}
