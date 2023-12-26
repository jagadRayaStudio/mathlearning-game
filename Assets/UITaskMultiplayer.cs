using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

namespace Animarket
{
    public class UITaskMultiplayer : MonoBehaviourPunCallbacks
    {
        [SerializeField] GameObject taskList;
        [SerializeField] GameObject task;


        [PunRPC]
        public void ReceiveQuestionData(QuestionData[] questionDataArray)
        {
            foreach (var questionData in questionDataArray)
            {
                CreateTaskUI(questionData);
            }
        }

        public void CreateTaskUI(QuestionData questionData)
        {
            GameObject newTask = Instantiate(task, taskList.transform);
            newTask.GetComponent<MultiplayerTask>().SetTask(questionData);
        }
    }
}