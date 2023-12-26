using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

namespace Animarket
{
    public class UIQuestion : MonoBehaviourPunCallbacks
    {
        [SerializeField] GameObject questionList;
        [SerializeField] GameObject questionPrefab;
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
            addButton.onClick.AddListener(AddQuestion);
            decreaseButton.onClick.AddListener(DecreaseQuestion);
            closeButton.onClick.AddListener(CloseScene);

            if (photonView.IsMine)
            {
                // If this is the teacher's view, set up for teacher actions
                // For example: UIQuestion setup, creating questions, etc.
            }
            else
            {
                // If this is a student's view, set up for student actions
                // For example: Waiting for teacher questions, displaying questions, etc.
            }
        }

        public override void OnEnable()
        {
            base.OnEnable();
            PhotonNetwork.AddCallbackTarget(this);
        }

        public override void OnDisable()
        {
            base.OnDisable();
            PhotonNetwork.RemoveCallbackTarget(this);
        }

        public void openShopPanel()
        {
            if (photonView.IsMine)
            {
                shopPanel.SetActive(true);
            }
        }

        private void CloseScene()
        {
            if (photonView.IsMine)
            {
                PhotonNetwork.LoadLevel("mainMenu");
            }
        }

        private void AddQuestion()
        {
            if (questionItems.Count < 10)
            {
                photonView.RPC("RPCAddQuestion", RpcTarget.AllBuffered, currentQuestionNumber);
            }
            else
            {
                // Handle jika sudah ada 10 pertanyaan
            }
        }

        private void DecreaseQuestion()
        {
            if (questionItems.Count > 0)
            {
                photonView.RPC("RPCDecreaseQuestion", RpcTarget.All);
            }
        }

        [PunRPC]
        private void RPCAddQuestion(int questionNumber)
        {
            GameObject newQuestion = Instantiate(questionPrefab, questionList.transform);
            questionItems.Add(newQuestion.GetComponent<questionScript>().gameObject);
            newQuestion.GetComponent<questionScript>().SetNumber(questionNumber);
            newQuestion.GetComponent<questionScript>().ResetAmount();
            currentQuestionNumber++;
        }

        [PunRPC]
        private void RPCDecreaseQuestion()
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