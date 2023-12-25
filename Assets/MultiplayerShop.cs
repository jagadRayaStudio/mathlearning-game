using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Animarket
{
    public class MultiplayerShop: MonoBehaviour
    {
        [SerializeField] Image icon;
        [SerializeField] TMP_Text shopName;

        public void SetShop(string _shopName, Sprite _shopIcon)
        {
            shopName.text = _shopName;
            icon.sprite = _shopIcon;
        }
    }
}
