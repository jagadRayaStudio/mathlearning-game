using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Animarket
{
    public class UITaskMultiplayer : MonoBehaviourPunCallbacks
    {
        [SerializeField] private GameObject taskPrefab;
        [SerializeField] private GameObject taskListParent;

        private List<MultiplayerTask> taskList = new List<MultiplayerTask>();

        private bool receivedTasks = false;

        public static UITaskMultiplayer Instance;

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

        public void SetReceivedTasksFlag(bool value)
        {
            receivedTasks = value;
            if (receivedTasks)
            {
                InitializeUI(TaskManagerMultiplayer.Instance.GetTaskList());
            }
        }

        public void InitializeUI(List<TaskData> receivedTaskData)
        {
            foreach (var task in taskList)
            {
                Destroy(task.gameObject);
            }

            taskList.Clear();

            foreach (var taskData in receivedTaskData)
            {
                GameObject newTaskItem = Instantiate(taskPrefab, taskListParent.transform);
                MultiplayerTask multiplayerTask = newTaskItem.GetComponent<MultiplayerTask>();
                multiplayerTask.Initialize(taskData);
                taskList.Add(multiplayerTask);
            }
        }

        public void TaskCompleted(TaskData completedTask)
        {
            var taskToRemove = taskList.Find(task => task.GetTaskData() == completedTask);
            if (taskToRemove != null)
            {
                Destroy(taskToRemove.gameObject);
                taskList.Remove(taskToRemove);

                Debug.Log($"Task Completed Locally - Number: {completedTask.taskNumber}, Name: {completedTask.taskName}, Amount: {completedTask.taskAmount}");
            }
        }

    }
}
