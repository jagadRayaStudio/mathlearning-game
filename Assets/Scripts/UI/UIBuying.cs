using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Animarket
{
    public class UIBuying : MonoBehaviour
    {
        [SerializeField] Image itemIcon;
        [SerializeField] TMP_Text itemNameText;
        [SerializeField] TMP_Text costText;
        [SerializeField] TMP_Text amountText;
        [SerializeField] TMP_InputField priceInputField;
        [SerializeField] Button increaseAmountButton;
        [SerializeField] Button decreaseAmountButton;

        private BuyingManager buyingManager;

        private void Start()
        {
            buyingManager = GetComponentInParent<BuyingManager>();
        }

        public void SetSelectedItem(Stock selectedItem)
        {
            itemIcon.sprite = selectedItem.item.sprite;
            itemNameText.text = selectedItem.item.itemName;
            costText.text = "Cost: " + selectedItem.item.cost.ToString();
            amountText.text = "Amount: " + buyingManager.GetTaskAmount().ToString();
            priceInputField.text = (buyingManager.GetTaskAmount() * selectedItem.item.cost).ToString();

            // Add listeners to buttons
            increaseAmountButton.onClick.AddListener(buyingManager.IncreaseAmount);
            decreaseAmountButton.onClick.AddListener(buyingManager.DecreaseAmount);
        }

        public void UpdatePriceInput()
        {
            int currentAmount = buyingManager.GetTaskAmount();
            priceInputField.text = (currentAmount * buyingManager.GetSelectedItem().item.cost).ToString();
        }

        public TMP_InputField GetPriceInputField()
        {
            return priceInputField;
        }
    }
}
