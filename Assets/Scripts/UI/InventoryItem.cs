using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InventoryItem : MonoBehaviour
    {
        public InventoryItemSO item;
        public int amount;
        [SerializeField] private TMPro.TextMeshProUGUI amountText;
        [SerializeField] private Image itemImage;
        
        
        public void Initialize(InventoryItemSO item, int amount)
        {
            this.item = item;
            this.amount = amount;
            UpdateUI();
        }


        private void UpdateUI()
        {
            amountText.text = amount.ToString();
            itemImage.sprite = item.itemImage;
            itemImage.gameObject.SetActive(true);
            

        }

        public void OnButtonClick()
        {
            InventoryManager.Instance.OnItemClicked(item);
        }

    }
}