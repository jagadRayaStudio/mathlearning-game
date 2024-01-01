using System.Collections.Generic;
using UnityEngine;

namespace Animarket
{
    public class ShopManager : MonoBehaviour
    {
        public Shop shopData;

        public void OpenShop()
        {
            UIShop.Instance.DisplayShop(shopData);
        }
    }
}
