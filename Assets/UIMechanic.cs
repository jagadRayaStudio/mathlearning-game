using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

namespace Animarket
{
    public class UIMechanic : MonoBehaviourPunCallbacks
    {
        [SerializeField] private TMP_Text productName;
        [SerializeField] private Image icon;
        [SerializeField] private TMP_Text cost;
        [SerializeField] private TMP_Text itemDesc;

        [SerializeField] private TMP_InputField amountInput;
        [SerializeField] private TMP_InputField totalInput;

        [SerializeField] private GameObject warningPanel;

        private Item selectedProduct;

        private void Start()
        {
            warningPanel.SetActive(false);
        }

        public void SetSelectedProduct(Item product)
        {
            selectedProduct = product;

            productName.text = selectedProduct.itemName;
            icon.sprite = selectedProduct.sprite;
            cost.text = selectedProduct.cost.ToString();
            itemDesc.text = selectedProduct.itemdesc;
        }

        public void SendAnswer()
        {
                TaskManagerMultiplayer taskManager = FindObjectOfType<TaskManagerMultiplayer>();

                List<TaskData> localTaskDataList = taskManager.GetTaskList();

                int inputAmount = int.Parse(amountInput.text);
                int inputTotal = int.Parse(totalInput.text);

                Debug.Log($"Selected Product: {selectedProduct.itemName}, Amount: {inputAmount}, Total: {inputTotal}");

                TaskData matchingTask = localTaskDataList.Find(task =>
                    task.taskName == selectedProduct.itemName &&
                    task.taskAmount == inputAmount &&
                    task.taskGrandTotal == inputTotal);

                if (matchingTask != null)
                {
                    Debug.Log($"Correct Answer! Task {matchingTask.taskName} completed.");
                    taskManager.RemoveTask(matchingTask);

                    UITaskMultiplayer.Instance.TaskCompleted(matchingTask);
                }
                else
                {
                    Debug.Log("Wrong Answer! No matching task found.");
                    // Tugas tidak cocok dengan jawaban yang diberikan
                    // Tambahkan logika penanganan kesalahan jika diperlukan
                }
        }


    }
}
