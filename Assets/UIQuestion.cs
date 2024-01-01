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
        [SerializeField] GameObject shopPanel;

        private Item selectedProduct;
        private QuestionManager questionManager;
        private int currentQuestionNumber = 1;

        private List<GameObject> questionItems = new List<GameObject>();
        public List<QuestionData> questionDataList = new List<QuestionData>();

        private void Awake()
        {
            questionManager = FindObjectOfType<QuestionManager>();

            shopPanel.SetActive(false);
        }

        public void openShopPanel()
        {
            shopPanel.SetActive(true);
        }

        private void CloseScene()
        {
            SceneManager.LoadScene("mainMenu");
        }

        private void addQuestion()
        {
            if (questionItems.Count < 10)
            {
                GameObject newQuestion = Instantiate(question, questionList.transform);
                questionItems.Add(newQuestion.GetComponent<questionScript>().gameObject);
                newQuestion.GetComponent<questionScript>().SetNumber(currentQuestionNumber);
                newQuestion.GetComponent<questionScript>().ResetAmount();
                currentQuestionNumber++;
            }
        }

        private void decreaseQuestion()
        {
            if (questionItems.Count > 0)
            {
                GameObject lastQuestion = questionItems[questionItems.Count - 1];
                int removedQuestionNumber = lastQuestion.GetComponent<questionScript>().GetNumber();
                questionItems.Remove(lastQuestion);
                Destroy(lastQuestion);

                if (removedQuestionNumber > 0)
                {
                    currentQuestionNumber--;
                }
            }
        }

        public void SetSelectedProduct(Item product)
        {
            if (questionItems.Count > 0)
            {
                questionItems[questionItems.Count - 1].GetComponent<questionScript>().SetSelectedProduct(product);
            }
        }

        public void startGame()
        {
            if (questionItems.Count > 0)
            {
                questionDataList.Clear();

                for (int i = 0; i < questionItems.Count; i++)
                {
                    QuestionData questionData = questionItems[i].GetComponent<questionScript>().GetQuestionData();
                    questionDataList.Add(questionData);
                }

                if (questionDataList.Count > 0)
                {
                    questionManager.InitializeQuestions(questionDataList);
                }
            }
        }
    }
}
