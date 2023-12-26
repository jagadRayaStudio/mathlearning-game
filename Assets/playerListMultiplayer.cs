using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;


namespace Animarket
{
    public class playerListMultiplayer : MonoBehaviourPunCallbacks
    {
        public static playerListMultiplayer Instance;

        private List<string> playerNameList = new List<string>();
        public playerName playerNamePrefab;
        public Transform playerNameParent;

        private void Awake()
        {
            Instance = this;
        }

        public void UpdatePlayerList(List<string> playerNames)
        {
            playerNameList.Clear();

            foreach (var playerName in playerNames)
            {
                playerNameList.Add(playerName);
                playerName newPlayerName = Instantiate(playerNamePrefab, playerNameParent);
                newPlayerName.SetPlayerName(playerName);
            }
        }

        public void ClearPlayerList()
        {
            playerNameList.Clear();
        }
    }

}