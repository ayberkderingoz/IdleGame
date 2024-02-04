using System.Collections.Generic;
using UnityEngine;

namespace Common.UI.Interfaces
{
    public interface IDepositable
    {
        GameObject repairReward { get; set; }
        Dictionary<MaterialType,int> materialNeeded { get; set; }
        Dictionary<MaterialType,int> currentMaterialDeposited { get; set; }
        
        void OpenRepairMenu();
        void DepositItem(MaterialType materialType, int amount);
        void ActivateRepairItem();



    }
}