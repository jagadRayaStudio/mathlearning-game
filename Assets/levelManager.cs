using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Animarket
{
    public class levelManager : MonoBehaviour
    {
        public Button[] buttons;

        private void Awake()
        {
            int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].interactable = false;
            }
            for (int i = 0; i < unlockedLevel; i++)
            {
                buttons[i].interactable = true;
            }
        }
        public void OpenLevel(int levelID)
        {
            string levelName = "Level" + levelID;
            SceneManager.LoadScene(levelName);
        }
    }
}
