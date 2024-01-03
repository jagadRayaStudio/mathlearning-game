using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Animarket
{
    [System.Serializable]
    public class Task
    {
        public Item item;
        public int amount;
        public int total;
        public bool isDone;
    }

    public class TaskManager : MonoBehaviour
    {
        [SerializeField] private List<Task> taskList;
        [SerializeField] GameObject winPanel;
        [SerializeField] Button toMenuButton;

        public List<Task> GetTaskList()
        {
            return taskList;
        }

        public void RemoveTask(Task task)
        {
            taskList.Remove(task);

            if (taskList.Count == 0)
            {
                winPanel.SetActive(true);
            }
        }

        private void Update()
        {
            toMenuButton.onClick.AddListener(BackToMainMenu);
        }

        private void BackToMainMenu()
        {
            SceneManager.LoadScene("mainMenu");
        }
    }
}
