using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Animarket
{
    [System.Serializable]
    public class QuestionData
    {
        public int number;
        public string itemName;
        public int cost;
        public int grandTotal;
        public int amount;
    }

    public class QuestionManager : MonoBehaviourPunCallbacks
    {
        public List<QuestionData> questionList = new List<QuestionData>();

        public void InitializeQuestions(List<QuestionData> questions)
        {
            questionList = questions;
            SendQuestionsToTaskManager();
        }

        private void SendQuestionsToTaskManager()
        {
            byte[] questionListBytes = ListToBytes(questionList);

            photonView.RPC("RPC_ReceiveQuestions", RpcTarget.All, questionListBytes);
        }

        private byte[] ListToBytes(List<QuestionData> list)
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
            {
                formatter.Serialize(stream, list);
                return stream.ToArray();
            }
        }

        [PunRPC]
        private void RPC_ReceiveQuestions(byte[] questionListBytes)
        {
            List<QuestionData> receivedQuestions = BytesToList(questionListBytes);

            FindObjectOfType<TaskManagerMultiplayer>().ReceiveQuestions(receivedQuestions);
        }

        private List<QuestionData> BytesToList(byte[] bytes)
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            using (System.IO.MemoryStream stream = new System.IO.MemoryStream(bytes))
            {
                return formatter.Deserialize(stream) as List<QuestionData>;
            }
        }
    }
}
