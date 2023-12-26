using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Animarket
{
    [System.Serializable]
    public class QuestionData: IPunObservable
    {
        public int QuestionNumber;
        public Sprite Icon;
        public string ItemName;
        public float Cost;
        public int Amount;
        public float GrandTotal;

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(QuestionNumber);
            }
            else
            {
                QuestionNumber = (int)stream.ReceiveNext();
            }
        }
    }

    public class UIQuestion : MonoBehaviourPunCallbacks
    {
        [SerializeField] GameObject questionList;
        [SerializeField] GameObject question;
        [SerializeField] GameObject shopPanel;
        public Button addButton;
        public Button decreaseButton;
        public Button closeButton;
        public Button startButton;
        
        private Item selectedProduct;
        private int currentQuestionNumber = 1;

        private List<GameObject> questionItems = new List<GameObject>();
        private List<QuestionData> questionDataList = new List<QuestionData>();

        private void Awake()
        {
            shopPanel.SetActive(false);
            addButton.onClick.AddListener(addQuestion);
            decreaseButton.onClick.AddListener(decreaseQuestion);
            closeButton.onClick.AddListener(CloseScene);
            startButton.onClick.AddListener(startGame);
            PhotonNetwork.AddCallbackTarget(this);
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

        public void startGame()
        {
            questionDataList.Clear();
            foreach (var questionItem in questionItems)
            {
                QuestionData data = new QuestionData
                {
                    QuestionNumber = questionItem.GetComponent<questionScript>().GetNumber(),
                    Icon = questionItem.GetComponent<questionScript>().GetIcon(),
                    ItemName = questionItem.GetComponent<questionScript>().GetItemName(),
                    Cost = questionItem.GetComponent<questionScript>().GetCost(),
                    Amount = questionItem.GetComponent<questionScript>().GetAmount(),
                    GrandTotal = questionItem.GetComponent<questionScript>().GetGrandTotal()
                };

                questionDataList.Add(data);
            }

            if (questionDataList.Count > 0)
            {
                photonView.RPC("ReceiveQuestionData", RpcTarget.Others, questionDataList.ToArray());
                Debug.Log("Data pertanyaan yang dikirim berjumlah " + questionDataList.Count);
            }
        }
    }
}
