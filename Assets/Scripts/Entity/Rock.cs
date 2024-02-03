using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : WorkableObject
{
    void Awake()
    {
        availablePositions = new Vector3[]
        {
            new Vector3(0, 0, 3),  
            new Vector3(3, 0, 0),  
            new Vector3(0, 0, -3), 
            new Vector3(-3, 0, 0) 
        };

        rewardType = MaterialType.Stone;
        maxWorkers = 3;

    }
}
