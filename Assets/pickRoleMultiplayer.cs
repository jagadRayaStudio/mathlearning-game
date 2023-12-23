using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Animarket
{

    public class pickRoleMultiplayer : MonoBehaviour
    {

        private void Start()
        {

        }

        public void pickTeacher()
        {
            SceneManager.LoadScene("TeacherScene");
        }
        public void pickStudent()
        {
            SceneManager.LoadScene("LobbyScene");
        }
    }

}