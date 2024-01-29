using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    void OnDisable()
    { 
        PlayerDataManager.Instance.SavePlayerData();
    }
    
    void OnApplicationQuit()
    {
        PlayerDataManager.Instance.SavePlayerData();
    }
}
