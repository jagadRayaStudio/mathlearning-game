using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

namespace Animarket
{

    public class LobbyScript : MonoBehaviourPunCallbacks
    {
        public TMP_InputField createInput;
        public TMP_InputField joinInput;

        public void CreateRoom()
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 6;
            PhotonNetwork.CreateRoom(createInput.text, roomOptions);
            Debug.Log("Guru Masuk");
        }

        public void JoinRoom()
        {
            PhotonNetwork.JoinRoom(joinInput.text);
            Debug.Log("Murid Masuk");
        }

        public override void OnJoinedRoom()
        {
            PhotonNetwork.LoadLevel("MultiplayerScene");
        }
    }
}