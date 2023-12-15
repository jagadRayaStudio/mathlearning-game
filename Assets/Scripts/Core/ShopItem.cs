using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Animarket {

    public class ShopItem : MonoBehaviour {
        public Image icon;
        public Stock stock;
        //public TMP_Text itemName;
        //public TMP_Text price;

        UIShop uishop;

        public void SetItem(Stock stockItem) {
            if (stockItem.item != null) {
                stock = stockItem;
                icon.sprite = stock.item.sprite;
                //itemName.text = stock.item.name;
                //price.text = stock.item.cost.ToString() + "Anikoin";
            }

            //this.stock = stock;
        }
        private void Awake() {
        }

        public Stock GetStock()
        {
            return stock;
        }
    }
}
