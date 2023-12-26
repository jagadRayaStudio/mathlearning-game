using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Animarket
{
    [System.Serializable]
    public class ShopInfo
    {
        public string shopName;
        public Sprite shopIcon;
        public List<Item> products;
    }

    public class MultiplayershopManager : MonoBehaviourPun
    {
        [SerializeField] private List<ShopInfo> shopList;

        public List<ShopInfo> GetShopList()
        {
            return shopList;
        }
    }
}
