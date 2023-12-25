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
        [SerializeField] TMP_Text amount;
        [SerializeField] TMP_Text itemName;
        [SerializeField] TMP_Text cost;
        [SerializeField] TMP_Text grandTotal;

        public Button openShop;
        public GameObject shopPanel;
        private int questionNumber;


        private void Awake()
        {
            shopPanel.SetActive(false);
        }
        private void Start()
        {
            openShop.onClick.AddListener(openShopPanel);
        }

        private void openShopPanel()
        {
            shopPanel.SetActive(true);
        }

        public void SetQuestion(Item _item, int _amount)
        {
            icon.sprite = _item.sprite;
            amount.text = _amount.ToString();
            itemName.text = _item.itemName;
            cost.text = _item.cost.ToString();
            float totalHarga = _amount * _item.cost;
            grandTotal.text = totalHarga.ToString();
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
            amount.text = string.Empty;
        }
    }
}