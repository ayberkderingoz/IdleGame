using Common.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InventoryDescription : MonoBehaviour
    {
        [SerializeField]
        private Image itemImage;
        [SerializeField]
        private TextMeshProUGUI title;
        [SerializeField]
        private TextMeshProUGUI description;
        
        private InventoryItemSO selectedItemSo;
        
        
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private Button selectAllButton;
        [SerializeField] private Button sellButton;
        [SerializeField] private TextMeshProUGUI sellGoldAmountText;
        [SerializeField] private GameObject sellConfirmationPanel;
        [SerializeField] private InventoryMenu _inventoryMenu;
        
        


        public void Awake()
        {
            ResetDescription();
            
        }
        

        public void ResetDescription()
        {
            itemImage.gameObject.SetActive(false);
            title.text = "";
            description.text = "";
            inputField.text = "";
            inputField.interactable = false;
            selectAllButton.interactable = false;
            sellButton.interactable = false;
            
        }

        public void SetDescription(InventoryItemSO item)
        {
            selectedItemSo = item;
            itemImage.gameObject.SetActive(true);
            itemImage.sprite = item.itemImage;
            title.text = item.itemName;
            description.text = item.description;
            inputField.text = "";
            inputField.interactable = true;
            selectAllButton.interactable = true;
        }
        
        
        
        public void OnInputFieldValueChanged()
        {
            if (inputField.text == "")
            {
                sellButton.interactable = false;
                sellGoldAmountText.text = "0";
            }
            else
            {
                CheckIfInventoryHasEnoughItems(inputField.text);
                sellButton.interactable = true;
                CalculateSellGoldAmount();
            }
        }
        public void OnSelectAllButtonClicked()
        {
            inputField.text = InventoryManager.Instance.GetItemCount(selectedItemSo.materialType).ToString();
            CalculateSellGoldAmount();
        }
        
        private void CalculateSellGoldAmount()
        {
            int amount = int.Parse(inputField.text);
            int goldAmount = amount * selectedItemSo.itemCost;
            sellGoldAmountText.text = goldAmount.ToString();
        }
        
        
        private void CheckIfInventoryHasEnoughItems(string input)
        {
            int amount = int.Parse(input);
            if (amount > InventoryManager.Instance.GetItemCount(selectedItemSo.materialType))
            {
                SetMaximumItemCount();
            }
        }
        
        private void SetMaximumItemCount()
        {
            inputField.text = InventoryManager.Instance.GetItemCount(selectedItemSo.materialType).ToString();
        }
        
        public void OnSellConfirmationButtonClicked()
        {
            sellConfirmationPanel.SetActive(true);
            _inventoryMenu.SetInteractable(false);

        }
        
        
        public void OnSellButtonClicked()
        {
            int amount = int.Parse(inputField.text);
            InventoryManager.Instance.RemoveItem(selectedItemSo.materialType, amount);
            PlayerDataManager.Instance.GainGold(amount * selectedItemSo.itemCost);
            ResetDescription();
            sellConfirmationPanel.SetActive(false);
            _inventoryMenu.SetInteractable(true);
        }
        
        

    }
}