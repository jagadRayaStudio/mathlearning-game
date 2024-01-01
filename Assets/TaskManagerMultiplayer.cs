// TaskManagerMultiplayer.cs
using System;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Animarket
{
    [System.Serializable]
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

        public void ReceiveQuestions(List<QuestionData> receivedQuestions)
        {
            Debug.Log($"Received {receivedQuestions.Count} question(s).");
            List<TaskData> taskDataList = ConvertQuestionsToTasks(receivedQuestions);
            SendTask();
        }

        public void SendTask()
        {
            UITaskMultiplayer uiTaskMultiplayer = FindObjectOfType<UITaskMultiplayer>();
            uiTaskMultiplayer.InitializeUI(taskDataList);
        }

        private List<TaskData> ConvertQuestionsToTasks(List<QuestionData> questions)
        {
            List<TaskData> taskDataList = new List<TaskData>();

            foreach (QuestionData questionData in questions)
            {
                TaskData taskData = GetTaskData(questionData);
                taskDataList.Add(taskData);
            }

            return taskDataList;
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

        public List<TaskData> GetTaskList()
        {
            return taskDataList;
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
                Debug.Log("Jawaban Benar!");
                return true;
            }
            else
            {
                Debug.Log("Jawaban Salah!");
                return false;
            }
        }
    }
}
