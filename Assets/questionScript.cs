using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Animarket
{
    public class questionScript : MonoBehaviour
    {
        [SerializeField] Image icon;
        [SerializeField] TMP_Text number;
        [SerializeField] TMP_Text itemName;
        [SerializeField] TMP_Text cost;
        [SerializeField] TMP_Text grandTotal;
        [SerializeField] TMP_InputField amountInputField;

        public Button openShop;
        private int questionNumber;
        private Item selectedProduct;

        private UIQuestion uiQuestion;

        private void Start()
        {
            uiQuestion = FindObjectOfType<UIQuestion>();
            openShop.onClick.AddListener(openShopPanel);
            amountInputField.onValueChanged.AddListener(UpdateGrandTotal);
        }

        private void openShopPanel()
        {
           uiQuestion.openShopPanel();
        }

        public void SetQuestion(Item _item, int _amount)
        {
            icon.sprite = _item.sprite;
            itemName.text = _item.itemName;
            cost.text = _item.cost.ToString();
            int inputAmount = int.Parse(amountInputField.text);
            grandTotal.text = (_item.cost * inputAmount).ToString();
        }

        public void SetNumber(int _number)
        {
            questionNumber = _number;
            number.text = _number.ToString();
        }

        public int GetNumber()
        {
            return questionNumber;
        }

        public void ResetAmount()
        {
            amountInputField.text = string.Empty;
        }

        public void SetSelectedProduct(Item product)
        {
            selectedProduct = product;
            icon.sprite = product.sprite;
            itemName.text = product.itemName;
            cost.text = product.cost.ToString();
            UpdateGrandTotal(amountInputField.text);
        }

        private void UpdateGrandTotal(string newValue)
        {
            int newAmount = int.Parse(newValue);
            grandTotal.text = (selectedProduct.cost * newAmount).ToString();
        }
    }
}