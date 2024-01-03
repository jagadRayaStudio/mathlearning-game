using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Animarket
{
    public class UITask : MonoBehaviour
    {
        public static UITask Instance { get; private set; }

        [SerializeField] GameObject taskItemParent;
        [SerializeField] GameObject taskItem;

        public GameObject taskPanel;

        private TaskManager taskManager;

        private List<GameObject> taskItems = new List<GameObject>();

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

            taskManager = FindObjectOfType<TaskManager>();
            taskPanel.SetActive(false);
        }

        private void Start()
        {
            UpdateTaskPanel();
        }

        void UpdateTaskPanel()
        {
            ClearTaskItems();

            foreach (var task in taskManager.GetTaskList())
            {
                if (!task.isDone)
                {
                    GameObject _tempTask = Instantiate(taskItem, taskItemParent.transform);
                    _tempTask.GetComponent<TaskItem>().SetTask(task.item, task.amount);
                    _tempTask.SetActive(true);
                    taskItems.Add(_tempTask);
                }
            }
        }

        public void TaskCompleted(Task completedTask)
        {
            UpdateTaskPanel();
        }

        void ClearTaskItems()
        {
            foreach (var taskItem in taskItems)
            {
                Destroy(taskItem);
            }
            taskItems.Clear();
        }
    }
}
