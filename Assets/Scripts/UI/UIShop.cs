using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Animarket
{
    public class UIShop : MonoBehaviour
    {
        public GameObject shopItemParent;
        public GameObject shopItemPrefab;

        public static UIShop Instance { get; private set; }

        private List<GameObject> shopItems = new List<GameObject>();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void DisplayShop(Shop shopData)
        {
            ClearChildren(shopItemParent);

            foreach (var shopItemData in shopData.shopItems)
            {
                GameObject shopItemObject = Instantiate(shopItemPrefab, shopItemParent.transform);
                shopItemObject.GetComponent<ShopItem>().SetShopItem(shopItemData, GetComponent<UIBuying>());
                shopItems.Add(shopItemObject);
            }
        }

        private void ClearChildren(GameObject parent)
        {
            foreach (Transform child in parent.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
