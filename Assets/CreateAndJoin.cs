using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

namespace Animarket
{

    public class CreateAndJoin : MonoBehaviourPunCallbacks
    {
        public TMP_InputField createInput;
        public TMP_InputField joinInput;

        public void CreateRoom()
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 6;
            PhotonNetwork.CreateRoom(createInput.text, roomOptions);
        }

        public void JoinRoom()
        {
            PhotonNetwork.JoinRoom(joinInput.text);
        }

        public override void OnJoinedRoom()
        {
            PhotonNetwork.LoadLevel("StudentScene");
        }
    }
}