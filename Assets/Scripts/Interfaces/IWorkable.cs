using System.Collections;
using System.Collections.Generic;
using Recruit;
using UnityEngine;

public interface IWorkable
{
    bool CanWorkOn(GameObject worker); 

    bool IsPositionAvailable(out Vector3 availablePosition);
    
    
    void StartWorking(Character character, GameObject worker); 

    void StopWorking(Character character,GameObject worker); 
    
    GameObject GetGameObject();

    int MaxWorkers { get; } 

    int CurrentWorkers { get; }
    
    Dictionary<Character,Coroutine> Jobs { get; }

    IEnumerator Work(Stats stats);
    


}
