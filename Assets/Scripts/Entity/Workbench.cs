using UnityEngine;

namespace Entity
{
    public class Workbench : WorkableObject
    {
         [SerializeField] private MaterialType _rewardType;
         [SerializeField] private int _maxWorkers;
         [SerializeField] private Vector3[] _availablePositions;
         [SerializeField] private MaterialType _materialUsed;
         [SerializeField] private float _workingTime;
         [SerializeField] private bool _isUsingMaterial;
         
         
            void Awake()
            {
                availablePositions = _availablePositions;
                rewardType = _rewardType;
                maxWorkers = _maxWorkers;
                materialUsed = _materialUsed;
                workingTime = _workingTime;
                isUsingMaterial = _isUsingMaterial;
            }
            
        
    }
}