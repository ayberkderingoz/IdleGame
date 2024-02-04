using System.Collections.Generic;
using Common.UI;
using Common.UI.Interfaces;
using UnityEngine;

namespace Entity
{
    public class DepositableObject : MonoBehaviour, IDepositable
    {
        public GameObject repairReward { get; set; }
        
        public Dictionary<MaterialType,int> materialNeeded { get; set; }
        public Dictionary<MaterialType,int> currentMaterialDeposited { get; set; }


        

        public void OpenRepairMenu()
        {
            DepositManager.Instance.InitializeDepositPanel(this,materialNeeded,currentMaterialDeposited, repairReward);
        }

        public void DepositItem(MaterialType materialType, int amount)
        {
            
            Debug.Log("Depositing " + amount + " " + materialType);
            currentMaterialDeposited[materialType] += amount;
            if (currentMaterialDeposited[materialType] >= materialNeeded[materialType])
            {
                currentMaterialDeposited[materialType] = materialNeeded[materialType];
            }
        }
        
        


        public void ActivateRepairItem()
        {
            repairReward.SetActive(true);
            gameObject.SetActive(false);
        }

    }
}