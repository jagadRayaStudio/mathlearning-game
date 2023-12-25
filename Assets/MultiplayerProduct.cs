using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Animarket
{
    public class MultiplayerProduct : MonoBehaviour
    {
        [SerializeField] Image icon;
        [SerializeField] TMP_Text productName;
        [SerializeField] TMP_Text productCost;

        public void SetProduct(Item item)
        {
            productName.text = item.itemName;
            productCost.text = item.cost.ToString();
            icon.sprite = item.sprite;
        }
    }
}
