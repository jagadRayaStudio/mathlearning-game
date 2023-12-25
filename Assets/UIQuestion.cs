using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Animarket
{

    public class UIQuestion : MonoBehaviour
    {
        [SerializeField] GameObject questionList;
        [SerializeField] GameObject question;
        public Button addButton;
        public Button decreaseButton;
        public Button closeButton;

        private List<GameObject> questionItems = new List<GameObject>();
        private int currentQuestionNumber = 2;

        private void Awake()
        {
            addButton.onClick.AddListener(addQuestion);
            decreaseButton.onClick.AddListener(decreaseQuestion);
            closeButton.onClick.AddListener(CloseScene);
        }

        private void CloseScene()
        {
            SceneManager.LoadScene("mainMenu");
        }

        private void addQuestion()
        {
            GameObject newQuestion = Instantiate(question, questionList.transform);
            questionItems.Add(newQuestion.GetComponent<questionScript>().gameObject);
            newQuestion.GetComponent<questionScript>().SetNumber(currentQuestionNumber);
            newQuestion.GetComponent<questionScript>().ResetAmount();
            currentQuestionNumber++;



        }

        private void decreaseQuestion()
        {
            if (questionItems.Count > 0)
            {
                GameObject lastQuestion = questionItems[questionItems.Count - 1];
                int removedQuestionNumber = lastQuestion.GetComponent<questionScript>().GetNumber();
                questionItems.Remove(lastQuestion);
                Destroy(lastQuestion);

                if (removedQuestionNumber > 1)
                {
                    currentQuestionNumber--;
                }
            }
        }
        /*void InstantiateTaskItem()
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
        */
    }
}