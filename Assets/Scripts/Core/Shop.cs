using UnityEngine;
using System.Collections.Generic;

namespace Animarket
{
    [CreateAssetMenu(fileName = "New Shop", menuName = "Shop")]

    public class Shop : ScriptableObject
    {
        public string shopName;
        public List<Item> shopItems;
    }
}