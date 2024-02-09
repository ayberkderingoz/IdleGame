using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSOHolder : MonoBehaviour
{
    //singleton
    public static ItemSOHolder instance;
    public static ItemSOHolder Instance => instance;
    
    public List<InventoryItemSO> itemSoList = new List<InventoryItemSO>();
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    public InventoryItemSO FindCorrespondingSo(MaterialType materialType)
    {
        return itemSoList.Find(x => x.materialType == materialType);
    }
    
    public List<InventoryItemSO> GetItemSoList()
    {
        return itemSoList;
    }
    
}
