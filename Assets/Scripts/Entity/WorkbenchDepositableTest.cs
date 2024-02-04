using System.Collections;
using Common.UI.Interfaces;
using UnityEngine;

namespace Entity
{
    public class WorkbenchDepositableTest : DepositableObject
    {
        
        [SerializeField] private GameObject repairRewardObject;
        void Start()
        {
            materialNeeded = new System.Collections.Generic.Dictionary<MaterialType, int>
            {
                {MaterialType.Stone, 20},
                {MaterialType.Wood, 1},
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