using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Animarket
{
    public class QuitGame : MonoBehaviour
    {
        public GameObject quitPanel;
        public Button quitButton;
        public Button yesButton;
        public Button noButton;

        void Start()
        {
            quitPanel.SetActive(false);
            noButton.onClick.AddListener(closeUI);
            yesButton.onClick.AddListener(closeGame);
            quitButton.onClick.AddListener(openQuitPanel);
        }

        void openQuitPanel()
        {
            quitPanel.SetActive(true);
        }

        void closeUI()
        {
            quitPanel.SetActive(false);
        }

        void closeGame()
        {
            Application.Quit();
        }
    }

}