using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Animarket
{
    public class MultiplayerShop : MonoBehaviour
    {
        [SerializeField] TMP_Text shopNameText;
        [SerializeField] Image shopIcon;

        public void SetShop(string shopName, Sprite shopIconSprite)
        {
            shopNameText.text = shopName;
            shopIcon.sprite = shopIconSprite;
        }
    }
}
