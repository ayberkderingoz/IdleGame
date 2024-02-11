using Entity;
using UnityEngine;

namespace DefaultNamespace
{
    public class RepairManager : MonoBehaviour
    {
        //singleton
        private static RepairManager _instance;
        public static RepairManager Instance => _instance;
        
        [SerializeField] private GameObject repairPanel;
        
        
        private void Awake()
        {
            if (Instance == null)
            {
                _instance = this;
            }
        }

        void Start()
        {
            
        }
        
        public void InitializeRepairPanel(RepairableObject repairableObject)
        {
            repairPanel.SetActive(true);
            repairPanel.GetComponent<RepairSkipPanel>().InitializePanel(repairableObject);
        }

    }
}