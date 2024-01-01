using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Animarket
{
    public class MultiplayerTask : MonoBehaviour
    {
        [SerializeField] TMP_Text numberText;
        [SerializeField] TMP_Text nameText;
        [SerializeField] TMP_Text amountText;

        private int cost;
        private int grandTotal;

        private TaskData taskData;

        public void Initialize(TaskData taskData)
        {
            this.taskData = taskData;
            numberText.text = taskData.taskNumber.ToString();
            nameText.text = taskData.taskName;
            amountText.text = taskData.taskAmount.ToString();
            cost = taskData.taskCost;
            grandTotal = taskData.taskGrandTotal;
        }
    }
}