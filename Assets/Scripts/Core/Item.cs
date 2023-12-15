using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animarket
{
    [CreateAssetMenu(fileName = "New Item", menuName = "Item")]
    public class Item : ScriptableObject
    {
        public string itemName;
        public int cost;
        public Sprite sprite;
        public string itemdesc;
    }
}
