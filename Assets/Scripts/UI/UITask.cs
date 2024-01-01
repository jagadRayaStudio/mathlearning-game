using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Animarket
{
    public class UITask : MonoBehaviour
    {
        [SerializeField] GameObject taskItemParent;
        [SerializeField] GameObject taskItem;

        public GameObject taskPanel;
        public GameObject taskTutorialPanel;

        private TaskManager taskManager;

        private List<GameObject> taskItems = new List<GameObject>();

        private void Awake()
        {
            taskManager = FindObjectOfType<TaskManager>();
            taskPanel.SetActive(false);
            taskTutorialPanel.SetActive(false);
        }

        private void Start()
        {

            InstantiateTaskItem();
        }

        void InstantiateTaskItem()
        {
            taskItems.Clear();

            foreach (var task in taskManager.GetTaskList())

            {
                GameObject _tempTask = Instantiate(taskItem, taskItemParent.transform);
                _tempTask.GetComponent<TaskItem>().SetTask(task.item, task.amount);
                _tempTask.SetActive(true);
                taskItems.Add(_tempTask);
            }
        }

        private void ShowTutorial()
        {
            taskTutorialPanel.SetActive(true);
        }

        private void CloseUI()
        {
            taskPanel.SetActive(false);
        }

        public void GetSelectedItem()
        {

        }
    }
}