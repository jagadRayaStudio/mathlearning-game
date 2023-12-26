using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Animarket
{
    public class playerName : MonoBehaviour
    {
        public TextMeshProUGUI playerNameText;

        public void SetPlayerName(string playerName)
        {
            playerNameText.text = playerName;
        }
    }
}