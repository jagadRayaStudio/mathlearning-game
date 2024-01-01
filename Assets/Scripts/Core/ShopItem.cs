using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Animarket
{

    public class ShopItem : MonoBehaviour
    {
        public Image icon;
        private int cost;
        private string itemName;
        private string itemDesc;

        public Button shopItemButton;

        public void SetShopItem(Item _item, UIBuying uiBuying)
        {
            icon.sprite = _item.sprite;
            itemName = _item.name;
            cost = _item.cost;
            itemDesc = _item.itemdesc;

            shopItemButton.onClick.AddListener(() => UIBuying.Instance.SetSelectedItem(_item));
        }
    }
}
