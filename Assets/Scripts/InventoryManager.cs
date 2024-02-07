using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Common.UI;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    //singleton
    private static InventoryManager _instance;
    public static InventoryManager Instance => _instance;
    
    public Dictionary<MaterialType, int> inventory = new Dictionary<MaterialType, int>(); //TODO: maybe change material type to item SO ? 
    
    public Action<Dictionary<MaterialType, int>> OnInventoryChanged;

    [SerializeField] private InventoryMenu inventoryMenu;
    
    


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
    public int GetItemCount(MaterialType materialType)
    {
        if (inventory.TryGetValue(materialType, out var value))
        {
            return value;
        }
        else
        {
            return 0;
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
    
    public void SortByType()
    {
        inventory = inventory.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
        OnInventoryChanged?.Invoke(inventory);
    }
    public void SortByAmoundAscending()
    {
        inventory = inventory.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        OnInventoryChanged?.Invoke(inventory);
    }
    public void SortByAmoundDescending()
    {
        inventory = inventory.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        OnInventoryChanged?.Invoke(inventory);
    }

    public void OnItemClicked(InventoryItemSO item)
    {
        inventoryMenu.SetDescriptionPanel(item);
    }

}
