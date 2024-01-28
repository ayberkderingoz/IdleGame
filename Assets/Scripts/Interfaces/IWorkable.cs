using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWorkable
{
    bool CanWorkOn(GameObject worker); 

    bool IsPositionAvailable(out Vector3 availablePosition);
    
    
    void StartWorking(GameObject worker); 

    void StopWorking(GameObject worker); 
    
    GameObject GetGameObject();

    int MaxWorkers { get; } 

    int CurrentWorkers { get; }

    IEnumerator Work();
    


}
