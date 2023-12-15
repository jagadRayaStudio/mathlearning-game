using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animarket
{
    [System.Serializable]
    public struct Stock
    {
        public Item item;
    }

    [System.Serializable]
    public class Shop
    {
        public int shopID;
        public string shopName;
        public List<Stock> stock;
    }

    public class ShopManager : MonoBehaviour
    {
        public List<Shop> shopList;
    }
}
