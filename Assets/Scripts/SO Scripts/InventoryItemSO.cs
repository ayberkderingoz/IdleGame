using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "InventoryItemSO", menuName = "InventoryItemSO", order = 0)]
public class InventoryItemSO: ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    public int itemCost;
    public string description;
    public MaterialType materialType;

}
