using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : WorkableObject
{

    [SerializeField] private MaterialType _rewardType;
    [SerializeField] private int _maxWorkers;
    [SerializeField] private Vector3[] _availablePositions;
    
    void Awake()
    {
        availablePositions = _availablePositions;
        rewardType = _rewardType;
        maxWorkers = _maxWorkers;

    }
}
