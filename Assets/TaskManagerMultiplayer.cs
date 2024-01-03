using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
            taskDataList.Clear();
            taskDataList = ConvertQuestionsToTasks(receivedQuestions);

            UITaskMultiplayer.Instance.SetReceivedTasksFlag(true);
        }

        private List<TaskData> ConvertQuestionsToTasks(List<QuestionData> questions)
        {
            List<TaskData> localTaskDataList = new List<TaskData>();

            foreach (QuestionData questionData in questions)
            {
                TaskData taskData = GetTaskData(questionData);
                localTaskDataList.Add(taskData);
            }

            return localTaskDataList;
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

        public void RemoveTask(TaskData taskToRemove)
        {
            if (photonView.IsMine)
            {
                bool taskRemoved = taskDataList.Remove(taskToRemove);

                if (taskRemoved && taskDataList.Count == 0)
                {
                    winPanel.SetActive(true);
                }
            }
        }
    }
}
