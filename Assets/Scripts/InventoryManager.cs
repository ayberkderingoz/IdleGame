using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    //singleton
    private static InventoryManager _instance;
    public static InventoryManager Instance => _instance;
    
    public Dictionary<MaterialType, int> inventory = new Dictionary<MaterialType, int>(); //TODO: maybe change material type to item SO ? 
    
    public Action<Dictionary<MaterialType, int>> OnInventoryChanged;
    
    


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
            OnInventoryChanged?.Invoke(inventory);
        }
        else
        {
            inventory.Add(materialType, amount);
            OnInventoryChanged?.Invoke(inventory);
        }
    }
    
    public void RemoveItem(MaterialType materialType, int amount)
    {
        if (inventory.ContainsKey(materialType))
        {
            inventory[materialType] -= amount;
            OnInventoryChanged?.Invoke(inventory);
        }
        else
        {
            Debug.LogError("Inventory does not contain this item");
        }
    }
    
    public bool HasEnoughItem(MaterialType materialType, int amount)
    {
        if (inventory.TryGetValue(materialType, out var value))
        {
            return value >= amount;
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


    public Dictionary<MaterialType,int> GetInventory()
    {
        return inventory;
    }
    
}
