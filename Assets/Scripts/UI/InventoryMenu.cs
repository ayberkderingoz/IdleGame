using System;
using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Common.UI
{
    public class InventoryMenu : MonoBehaviour
    {
        [SerializeField] private InventoryItem itemPrefab;
        [SerializeField] private RectTransform contentPanel;

        
        public List<InventoryItem> items = new List<InventoryItem>();
        
        
        private bool _isInventoryOpen = false; //TODO: implement this to performance optimization while inventory is not open (not updating the UI)
        
        
        
        public List<InventoryItemSO> inventoryItems = new List<InventoryItemSO>();


        



        void Start()
        {
            InventoryManager.Instance.OnInventoryChanged += OnInventoryChanged;
            InitializeInventoryUI();
            
        }

        private void InitializeInventoryUI()
        {

            var materialCount = Enum.GetNames(typeof(MaterialType)).Length;
            for(int i = 0;i < materialCount;i++)
            {
                var item = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity,contentPanel);
                //item.transform.SetParent(contentPanel);
                items.Add(item);
            }
        }

        private void OnInventoryChanged(Dictionary<MaterialType, int> inventory)
        {
            
            int startIndex = 0;
            foreach (var pair in inventory)
            {
                var itemSo = FindCorrespondingSo(pair.Key);
                if (itemSo == null) continue;
                items[startIndex].Initialize(itemSo, pair.Value);
                startIndex++;
            }
        }


        private InventoryItemSO FindCorrespondingSo(MaterialType materialType)
        {
            return inventoryItems.FirstOrDefault(item => item.materialType == materialType);
        }


        void OnEnable()
        {
            Debug.Log("InventoryMenu is enabled");
        }

    }
}