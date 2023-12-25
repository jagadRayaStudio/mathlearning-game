using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Animarket
{
    public class MultiplayerShopUI : MonoBehaviour
    {
        [SerializeField] GameObject ShopPrefab;
        [SerializeField] Transform shopList;

        public void PopulateShopList(List<ShopInfo> shopInfos)
        {
            ClearShopList();

            foreach (ShopInfo shopInfo in shopInfos)
            {
                GameObject newItemShop = Instantiate(ShopPrefab, shopList);
                newItemShop.GetComponent<MultiplayerShop>().SetShop(shopInfo.shopName, shopInfo.shopIcon);
            }
        }

        private void ClearShopList()
        {
            foreach (Transform child in shopList)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
