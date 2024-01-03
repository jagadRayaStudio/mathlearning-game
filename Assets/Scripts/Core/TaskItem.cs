using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Animarket
{
    public class TaskItem : MonoBehaviour
    {
        [SerializeField] public Image icon;
        [SerializeField] public TMP_Text amount;
        [SerializeField] public TMP_Text itemName;


        public void SetTask(Item _item, int _amount)
        {
            icon.sprite = _item.sprite;
            amount.text = _amount.ToString();
            itemName.text = _item.itemName;
        }
    }
}
