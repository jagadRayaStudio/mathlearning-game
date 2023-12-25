using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animarket
{
    [System.Serializable]
    public class ProductInfo
    {
        public string productName;
        public Sprite productIcon;
        public int price;
    }

    [System.Serializable]
    public class ShopInfo
    {
        public string shopName;
        public Sprite shopIcon;
        public List<ProductInfo> products;
    }

    public class MultiplayershopManager : MonoBehaviour
    {
        public List<ShopInfo> shopInfos = new List<ShopInfo>();
    }
}
