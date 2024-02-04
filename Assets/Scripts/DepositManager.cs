using System;
using System.Collections.Generic;
using Entity;
using UI;
using UnityEngine;

namespace Common.UI
{
    public class DepositManager : MonoBehaviour
    {
        private static DepositManager _instance;
        public static DepositManager Instance => _instance;
        
        [SerializeField] private GameObject depositPanel;
        
        public DepositableObject currentDepositableObject;
        
        public Action<MaterialType,int> OnDepositItem;
        
        
        private void Awake()
        {
            if (Instance == null)
            {
                _instance = this;
            }
        }
        
        
        public void InitializeDepositPanel(DepositableObject depositableObject,Dictionary<MaterialType,int> materialNeeded,Dictionary<MaterialType,int> currentMaterialDeposited, GameObject repairReward)
        {
            currentDepositableObject = depositableObject;
            depositPanel.SetActive(true);
            depositPanel.GetComponent<DepositPanel>().InitializeDepositPanel(materialNeeded,currentMaterialDeposited, repairReward);
        }
        
        public void DepositItem(MaterialType materialType, int amount)
        {
            currentDepositableObject.DepositItem(materialType,amount);
            depositPanel.GetComponent<DepositPanel>().CheckIfRepairAvailable(currentDepositableObject.materialNeeded,currentDepositableObject.currentMaterialDeposited);
        }
        
        public void StartRepairingCurrentObject()
        {
            currentDepositableObject.ActivateRepairItem();
        }
        
        
        
        
    }
}