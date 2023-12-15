using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Animarket
{
    public class UITask : UIAnim
    {
        [SerializeField] GameObject taskItemParent;
        [SerializeField] GameObject taskItem;

        public GameObject taskPanel;
        public GameObject taskTutorialPanel;
        public Button helpButton;
        public Button closeButton;

        private TaskManager taskManager;

        private List<GameObject> taskItems = new List<GameObject>();

        private bool taskItemsInstantiated = false;

        protected override void Awake()
        {
            taskManager = FindObjectOfType<TaskManager>();
            base.Awake();
        }

        public override void OnEnable()
        {
            if (!taskItemsInstantiated)
            {
                InstantiateTaskItem();
                taskItemsInstantiated = true;
            }
            else
            {
                foreach (var taskItem in taskItems)
                {
                    taskItem.SetActive(true);
                }
            }

            helpButton.onClick.AddListener(ShowTutorial);
            closeButton.onClick.AddListener(CloseUI);
            base.OnEnable();
        }

        public override void StartDisable()
        {
            foreach (var taskItem in taskItems)
            {
                taskItem.SetActive(false);
            }
            base.StartDisable();
        }

        private void ShowTutorial()
        {
            taskTutorialPanel.SetActive(true);
        }

        private void CloseUI()
        {
            taskPanel.SetActive(false);
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
    }
}