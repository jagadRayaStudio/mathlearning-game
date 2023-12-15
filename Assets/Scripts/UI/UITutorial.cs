using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Animarket
{
    public class UITutorial : MonoBehaviour
    {
        public Transform tutorialListParent;
        public Button nextButton;
        public Button previousButton;
        public Button closeButton;
        public GameObject tutorialPanel;

        private int currentTutorialIndex = 0;

        private void Start()
        {
            nextButton.onClick.AddListener(ShowNextTutorial);
            previousButton.onClick.AddListener(ShowPreviousTutorial);
            closeButton.onClick.AddListener(closeUI);
            ShowCurrentTutorial();
        }

        private void ShowCurrentTutorial()
        {
            for (int i = 0; i < tutorialListParent.childCount; i++)
            {
                tutorialListParent.GetChild(i).gameObject.SetActive(false);
            }

            tutorialListParent.GetChild(currentTutorialIndex).gameObject.SetActive(true);
        }

        private void ShowNextTutorial()
        {
            if (currentTutorialIndex < tutorialListParent.childCount - 1)
            {
                currentTutorialIndex++;
                ShowCurrentTutorial();
            }
        }

        private void ShowPreviousTutorial()
        {
            if (currentTutorialIndex > 0)
            {
                currentTutorialIndex--;
                ShowCurrentTutorial();
            }
        }

        private void closeUI()
        {
            tutorialPanel.SetActive(false);
        }
    }
}