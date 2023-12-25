using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Animarket
{

    public class MultiplayerPanel : MonoBehaviour
    {
        public GameObject goToMultiplayerPanel;

        public void closeUI()
        {
            goToMultiplayerPanel.SetActive(false);
        }
        public void goToMultiplayer()
        {
            SceneManager.LoadScene("LoadingScene");
        }
    }

}