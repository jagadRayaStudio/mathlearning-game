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

        private QuestionData questionData;

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

        public Sprite GetIcon()
        {
            return icon.sprite;
        }

        public string GetItemName()
        {
            return itemName.text;
        }

        public float GetCost()
        {
            return float.Parse(cost.text);
        }

        public int GetAmount()
        {
            return int.Parse(amountInputField.text);
        }

        public float GetGrandTotal()
        {
            return float.Parse(grandTotal.text);
        }


        private void UpdateGrandTotal(string newValue)
        {
            int newAmount = int.Parse(newValue);
            grandTotal.text = (selectedProduct.cost * newAmount).ToString();
        }

        public QuestionData GetQuestionData()
        {
            questionData = new QuestionData();
            questionData.number = GetNumber();
            questionData.itemName = GetItemName();
            questionData.cost = (int)GetCost();
            questionData.grandTotal = (int)GetGrandTotal();
            questionData.amount = GetAmount();

            return questionData;
        }
    }
}