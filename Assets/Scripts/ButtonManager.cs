using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    
    
    
    public void ActivateGameobject(GameObject gameObj)
    {
        gameObj.SetActive(true);
    }
    public void DeactivateGameobject(GameObject gameObj)
    {
        gameObj.SetActive(false);
    }

}
