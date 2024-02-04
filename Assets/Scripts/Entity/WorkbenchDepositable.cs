using System.Collections;
using Common.UI.Interfaces;
using UnityEngine;

namespace Entity
{
    public class WorkbenchDepositable : DepositableObject
    {
        
        [SerializeField] private GameObject repairRewardObject;
        void Start()
        {
            materialNeeded = new System.Collections.Generic.Dictionary<MaterialType, int>
            {
                {MaterialType.Wood, 5},
                {MaterialType.Stone, 2},
            };
            currentMaterialDeposited = new System.Collections.Generic.Dictionary<MaterialType, int>
            {
                {MaterialType.Wood, 0},
                {MaterialType.Stone, 0},
            };
            
            repairReward = repairRewardObject;
        }
        
    }
}