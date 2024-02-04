using Common.UI;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DepositItem : MonoBehaviour
    {
        public InventoryItemSO item;
        public int amountNeeded;
        public int depositedAmount;
        [SerializeField] private TMPro.TextMeshProUGUI amountText;
        [SerializeField] private Image itemImage;
        [SerializeField] private Button depositButton;

        
        
        
        public void Initialize(InventoryItemSO item, int amountNeeded, int depositedAmount)
        {
            this.item = item;
            this.amountNeeded = amountNeeded;
            this.depositedAmount = depositedAmount;
            UpdateUI();
        }


        private void UpdateUI()
        {
            amountText.text = depositedAmount + "/" + amountNeeded;
            itemImage.sprite = item.itemImage;
            itemImage.gameObject.SetActive(true);
        }
        
        public void Deposit()
        {
            var itemCountInventory = InventoryManager.Instance.GetItemCount(item.materialType);
            if (itemCountInventory >= amountNeeded - depositedAmount)
            {
                InventoryManager.Instance.RemoveItem(item.materialType, amountNeeded - depositedAmount);
                DepositManager.Instance.DepositItem(item.materialType, amountNeeded - depositedAmount);
                depositedAmount = amountNeeded;
                
            }
            else
            {
                InventoryManager.Instance.RemoveItem(item.materialType, itemCountInventory);
                DepositManager.Instance.DepositItem(item.materialType, itemCountInventory);
                depositedAmount += itemCountInventory;
            }
            
            UpdateUI();
        }
    }
}