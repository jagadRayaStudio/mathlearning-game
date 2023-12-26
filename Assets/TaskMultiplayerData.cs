using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animarket
{
    [System.Serializable]
    public class TaskMultiplayerData : MonoBehaviour
    {
        public int TaskNumber;
        public Sprite Icon;
        public string ItemName;
        public int Amount;
        public float GrandTotal;
    }
}