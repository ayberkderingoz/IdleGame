using System.Collections.Generic;
using UnityEngine;

namespace Entity
{
    public class WorkbenchDepositable : DepositableObject
    {
        
        [SerializeField] private GameObject repairRewardObject;
        void Start()
        {
            materialNeeded = new Dictionary<MaterialType, int>
            {
                {MaterialType.Wood, 5},
                {MaterialType.Stone, 2},
            };
            currentMaterialDeposited = new Dictionary<MaterialType, int>
            {
                {MaterialType.Wood, 0},
                {MaterialType.Stone, 0},
            };
            
            repairReward = repairRewardObject;
        }
        
    }
}