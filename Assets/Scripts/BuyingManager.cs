using UnityEngine;

namespace Animarket
{
    public class BuyingManager : MonoBehaviour
    {
        private UIShop shopUI;
        private TaskManager taskManager;
        private Stock selectedItem;
        private UIBuying buyingUI;

        private void Awake()
        {
            shopUI = GetComponentInParent<UIShop>();
            taskManager = GameObject.FindObjectOfType<TaskManager>();
            buyingUI = GetComponentInChildren<UIBuying>();
        }

        private void OnEnable()
        {
            selectedItem = shopUI.GetSelectedItem();
            buyingUI.SetSelectedItem(selectedItem);
        }

        public int GetTaskAmount()
        {
            return taskManager.GetTaskAmount(selectedItem.item);
        }

        public Stock GetSelectedItem()
        {
            return selectedItem;
        }

        public void IncreaseAmount()
        {
            int currentAmount = taskManager.GetTaskAmount(selectedItem.item);
            taskManager.SetTaskAmount(selectedItem.item, currentAmount + 1);
            buyingUI.UpdatePriceInput();
        }

        public void DecreaseAmount()
        {
            int currentAmount = taskManager.GetTaskAmount(selectedItem.item);
            if (currentAmount > 0)
            {
                taskManager.SetTaskAmount(selectedItem.item, currentAmount - 1);
                buyingUI.UpdatePriceInput();
            }
        }

        public void CheckPriceInput()
        {
            int enteredPrice = int.Parse(buyingUI.GetPriceInputField().text);

            if (enteredPrice != (GetTaskAmount() * selectedItem.item.cost))
            {
                Task tempTask = taskManager.GetTaskFromItemObject(selectedItem.item);
                taskManager.SetTaskDone(tempTask, false);
            }
            else
            {
                Task tempTask = taskManager.GetTaskFromItemObject(selectedItem.item);
                taskManager.SetTaskDone(tempTask, true);
            }
        }
    }
}
