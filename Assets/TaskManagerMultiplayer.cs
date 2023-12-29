using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Animarket
{
    public class TaskData
    {
        public int taskNumber;
        public string taskName;
        public int taskCost;
        public int taskGrandTotal;
        public int taskAmount;
    }

    public class TaskManagerMultiplayer : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Transform taskListParent;
        [SerializeField] private GameObject taskPrefab;
        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject losePanel;

        private List<TaskData> taskDataList = new List<TaskData>();

        public static TaskManagerMultiplayer Instance;

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

            winPanel.SetActive(false);
            losePanel.SetActive(false);
        }

        public void ReceiveQuestions(QuestionData[] receivedQuestions)
        {
            for (int i = 0; i < receivedQuestions.Length; i++)
            {
                TaskData taskData = GetTaskData(receivedQuestions[i]);
                taskDataList.Add(taskData);
                GameObject newTaskItem = PhotonNetwork.Instantiate(taskPrefab.name, Vector3.zero, Quaternion.identity);
                MultiplayerTask multiplayerTask = newTaskItem.GetComponent<MultiplayerTask>();
                multiplayerTask.Initialize(taskData);
            }
        }

        private TaskData GetTaskData(QuestionData questionData)
        {
            TaskData taskData = new TaskData
            {
                taskNumber = questionData.number,
                taskName = questionData.itemName,
                taskCost = questionData.cost,
                taskGrandTotal = questionData.grandTotal,
                taskAmount = questionData.amount
            };

            return taskData;
        }

        public void CheckAnswer(Item selectedProduct, int amount, int grandTotal)
        {
            if (photonView.IsMine)
            {
                TaskData matchingTask = null;

                foreach (TaskData taskData in taskDataList)
                {
                    if (IsAnswerCorrect(taskData, selectedProduct, amount, grandTotal))
                    {
                        matchingTask = taskData;
                        break;
                    }
                }

                if (matchingTask != null)
                {
                    taskDataList.Remove(matchingTask);
                    winPanel.SetActive(true);

                }
                else
                {
                    losePanel.SetActive(false);
                }
            }
        }

        private bool IsAnswerCorrect(TaskData taskData, Item selectedProduct, int amount, int grandTotal)
        {
            if (selectedProduct.itemName == taskData.taskName &&
                amount == taskData.taskAmount &&
                grandTotal == taskData.taskGrandTotal)

            {
                return true;
                Debug.Log("Jawaban Benar!");
            }
            else
            {
                Debug.Log("Jawaban Salah!");
            }
            return false;

        }

    }
}
