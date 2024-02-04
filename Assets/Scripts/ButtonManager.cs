using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    private int _sortCount = 0;
    
    
    public void ActivateGameobject(GameObject gameObj)
    {
        gameObj.SetActive(true);
    }
    public void DeactivateGameobject(GameObject gameObj)
    {
        gameObj.SetActive(false);
    }

    public void SortInventory()
    {
        switch(_sortCount)
        {
            case 0:
                InventoryManager.Instance.SortByType();
                _sortCount++;
                break;
            case 1:
                InventoryManager.Instance.SortByAmoundAscending();
                _sortCount++;
                break;
            case 2:
                InventoryManager.Instance.SortByAmoundDescending();
                _sortCount = 0;
                break;
            default:
                break;
        }
    }

}
