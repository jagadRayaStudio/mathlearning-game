using Animarket;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Animarket
{
    public class loadPanel : MonoBehaviour
    {
        public DialogueManager dialogueManager;
        public GameObject levelPanel;

        private void Awake()
        {
            levelPanel.SetActive(false);
        }

        private void Start()
        {
            dialogueManager.OnDialogueEnd += HandleDialogueEnd;
        }

        public void HandleDialogueEnd()
        {
            levelPanel.SetActive(true);
        }
    }
}
