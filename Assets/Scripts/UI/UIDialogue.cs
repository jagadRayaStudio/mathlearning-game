using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Animarket
{
    public class UIDialogue : MonoBehaviour
    {
        [SerializeField] private GameObject dialoguePanel;
        [SerializeField] private TextMeshProUGUI dialogueText;

        public void Show()
        {
            dialoguePanel.SetActive(true);
        }

        public void Hide()
        {
            dialoguePanel.SetActive(false);
        }

        public void DisplayText(string text)
        {
            dialogueText.text = text;
        }
    }
}
