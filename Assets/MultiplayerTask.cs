using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Animarket
{
    public class MultiplayerTask : MonoBehaviourPunCallbacks
    {
        [SerializeField] Image icon;
        [SerializeField] TMP_Text number;
        [SerializeField] TMP_Text itemName;
        [SerializeField] TMP_Text amount;
        [SerializeField] private TMP_Text grandTotal;

        public void SetTask(QuestionData questionData)
        {
            icon.sprite = questionData.Icon;
            itemName.text = questionData.ItemName;
            grandTotal.text = questionData.GrandTotal.ToString();
            amount.text = questionData.Amount.ToString();
        }
    }
}