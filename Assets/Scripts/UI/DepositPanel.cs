using System;
using System.Collections.Generic;
using Common.UI;
using UnityEngine;

namespace UI
{
    public class DepositPanel : MonoBehaviour
    {
        
        [SerializeField] private GameObject depositItemPrefab;
        [SerializeField] private GameObject contentPanel;
        [SerializeField] private GameObject startRepairButton;
        
        private Dictionary<MaterialType,int> materialNeeded;
        private Dictionary<MaterialType,int> currentMaterialDeposited;
        
        
        public void InitializeDepositPanel(Dictionary<MaterialType,int> materialNeeded,Dictionary<MaterialType,int> currentMaterialDeposited, GameObject repairReward){
            //instantiate material needed times depositItemPrefab
            foreach (var material in materialNeeded)
            {
                GameObject depositItem = Instantiate(depositItemPrefab, contentPanel.transform);
                depositItem.GetComponent<DepositItem>().Initialize(ItemSOHolder.Instance.FindCorrespondingSo(material.Key), material.Value, currentMaterialDeposited[material.Key]);
            }
            this.materialNeeded = materialNeeded;
            this.currentMaterialDeposited = currentMaterialDeposited;
            CheckIfRepairAvailable(materialNeeded,currentMaterialDeposited);

        }
        public void CheckIfRepairAvailable(Dictionary<MaterialType,int> materialNeed, Dictionary<MaterialType,int> currentMaterialDeposit)
        {
            bool repairAvailable = true;
            foreach (var material in materialNeed)
            {
                if (currentMaterialDeposit[material.Key] < material.Value)
                {
                    repairAvailable = false;
                }
            }
            ChangeRepairButtonState(repairAvailable);
            
        }



        private void ChangeRepairButtonState(bool isAvailable)
        {
            startRepairButton.SetActive(isAvailable);
        }

        public void StartRepair()
        {
            DepositManager.Instance.StartRepairingCurrentObject();
            gameObject.SetActive(false);
        }
        

        private void OnDisable()
        {
            foreach (Transform child in contentPanel.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}