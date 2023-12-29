using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

namespace Animarket
{
    public class UIMechanic : MonoBehaviourPunCallbacks
    {
        [SerializeField] private TMP_Text productName;
        [SerializeField] private Image icon;
        [SerializeField] private TMP_Text cost;
        [SerializeField] private TMP_Text itemDesc;

        [SerializeField] private TMP_InputField amountInput;
        [SerializeField] private TMP_InputField totalInput;
        [SerializeField] private Button sendAnswerButton;

        [SerializeField] private GameObject warningPanel;

        private Item selectedProduct;

        private void Start()
        {
            warningPanel.SetActive(false);
            sendAnswerButton.onClick.AddListener(SendAnswer);
        }

        public void SetSelectedProduct(Item product)
        {
            selectedProduct = product;

            productName.text = selectedProduct.itemName;
            icon.sprite = selectedProduct.sprite;
            cost.text = selectedProduct.cost.ToString();
            itemDesc.text = selectedProduct.itemdesc;
        }

        private void SendAnswer()
        {
            if (photonView.IsMine)
            {
                int amount = 0;
                if (int.TryParse(amountInput.text, out amount))
                {
                    int grandTotal = 0;
                    if (int.TryParse(totalInput.text, out grandTotal))
                    {
                        TaskManagerMultiplayer.Instance.CheckAnswer(selectedProduct, amount, grandTotal);
                    }
                    else
                    {
                        warningPanel.SetActive(true);
                    }
                }
                else
                {
                    warningPanel.SetActive(true);
                }
            }
        }
    }
}
