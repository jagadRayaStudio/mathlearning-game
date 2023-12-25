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
        [SerializeField] GameObject shopPanel;
        public Button addButton;
        public Button decreaseButton;
        public Button closeButton;

        
        private Item selectedProduct;
        private List<GameObject> questionItems = new List<GameObject>();
        private int currentQuestionNumber = 1;

        private void Awake()
        {
            shopPanel.SetActive(false);
            addButton.onClick.AddListener(addQuestion);
            decreaseButton.onClick.AddListener(decreaseQuestion);
            closeButton.onClick.AddListener(CloseScene);
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
            else
            {

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
            foreach (var questionItem in questionItems)
            {
                questionItem.GetComponent<questionScript>().SetSelectedProduct(product);
            }
        }
    }
}