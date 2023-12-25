using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Animarket
{
    public class questionScript : MonoBehaviour
    {
        [SerializeField] Button icon;
        [SerializeField] TMP_Text number;
        [SerializeField] TMP_Text amount;
        [SerializeField] TMP_Text itemName;
        [SerializeField] TMP_Text cost;
        [SerializeField] TMP_Text grandTotal;
        [SerializeField] GameObject shopPanel;

        private int questionNumber;

        private void Start()
        {
            icon.onClick.AddListener(ShowShopPanel);
        }

        public void SetQuestion( Item _item, int _amount)
        {
            icon.image.sprite = _item.sprite;
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

        private void ShowShopPanel()
        {
            shopPanel.SetActive(true);
        }
    }
}