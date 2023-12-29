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
        public QuestionData[] questionArray;

        public void InitializeQuestions(QuestionData[] questions)
        {
            questionArray = questions;

            byte[] questionsAsBytes = objectToBytes(questionArray);
            photonView.RPC("RPC_ReceiveQuestions", RpcTarget.All, "Testevent", questionsAsBytes);
        }

        [PunRPC]
        private void RPC_ReceiveQuestions(string eventName, byte[] argsAsBytes)
        {
            QuestionData[] receivedQuestions = bytesToObject(argsAsBytes) as QuestionData[];

            FindObjectOfType<TaskManagerMultiplayer>().ReceiveQuestions(receivedQuestions);
        }

        private byte[] objectToBytes(object obj)
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
            {
                formatter.Serialize(stream, obj);
                return stream.ToArray();
            }
        }

        private object bytesToObject(byte[] bytes)
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            using (System.IO.MemoryStream stream = new System.IO.MemoryStream(bytes))
            {
                return formatter.Deserialize(stream);
            }
        }
    }
}
