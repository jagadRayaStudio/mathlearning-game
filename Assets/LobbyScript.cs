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
        public TMP_InputField nameInput;

        public void ChangeName()
        {
            PhotonNetwork.NickName = nameInput.text;
        }

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
            PhotonNetwork.LoadLevel("MultiplayerScene");

            photonView.RPC("UpdatePlayerListRPC", RpcTarget.All);
        }

        [PunRPC]
        void UpdatePlayerListRPC()
        {
            playerListMultiplayer.Instance.ClearPlayerList();

            if (PhotonNetwork.CurrentRoom == null)
            {
                return;
            }

            List<string> playerNames = new List<string>();

            foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
            {
                playerNames.Add(player.Value.NickName);
            }
            playerListMultiplayer.Instance.UpdatePlayerList(playerNames);
        }
    }
}