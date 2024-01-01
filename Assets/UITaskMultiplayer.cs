using System.Collections.Generic;
using UnityEngine;

namespace Animarket
{
    public class UITaskMultiplayer : MonoBehaviour
    {
        [SerializeField] private GameObject taskPrefab;
        [SerializeField] private GameObject taskListParent;

        private List<MultiplayerTask> taskList = new List<MultiplayerTask>();

        private void Start()
        {
            InitializeUI(TaskManagerMultiplayer.Instance.GetTaskList());
        }

        public void InitializeUI(List<TaskData> receivedTaskData)
        {
            foreach (TaskData taskData in receivedTaskData)
            {
                GameObject newTaskItem = Instantiate(taskPrefab, taskListParent.transform);
                MultiplayerTask multiplayerTask = newTaskItem.GetComponent<MultiplayerTask>();
                multiplayerTask.Initialize(taskData);
                taskList.Add(multiplayerTask);
            }
        }
    }
}
