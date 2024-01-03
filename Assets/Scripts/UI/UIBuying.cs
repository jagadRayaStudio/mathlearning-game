using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Animarket
{
    public class UIBuying : MonoBehaviour
    {
        [SerializeField] Image itemIcon;
        [SerializeField] TMP_Text itemNameText;
        [SerializeField] TMP_Text costText;
        [SerializeField] TMP_Text desc;
        [SerializeField] TMP_InputField amountInput;
        [SerializeField] TMP_InputField totalInput;

        public static UIBuying Instance { get; private set; }
        private Item selectedItem;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void SetSelectedItem(Item item)
        {
            selectedItem = item;
            itemIcon.sprite = selectedItem.sprite;
            itemNameText.text = selectedItem.name;
            costText.text = selectedItem.cost.ToString();
            desc.text = selectedItem.itemdesc.ToString();
        }

        public void CheckAnswer()
        {
            List<Task> taskList = FindObjectOfType<TaskManager>().GetTaskList();

            int inputAmount = int.Parse(amountInput.text);
            int inputTotal = int.Parse(totalInput.text);

            Debug.Log($"Checking Answer for {selectedItem.name}, Amount: {inputAmount}, Total: {inputTotal}");

            TaskManager taskManager = FindObjectOfType<TaskManager>();

            foreach (Task task in taskList)
            {
                if (!task.isDone && task.item == selectedItem && task.amount == inputAmount && task.total == inputTotal)
                {
                    Debug.Log("Task Completed!");
                    task.isDone = true;
                    taskManager.RemoveTask(task);
                    UITask.Instance.TaskCompleted(task);
                    Debug.Log($"Task {task.item.name} removed from the task list.");
                    break;
                }
            }
        }

    }
}
