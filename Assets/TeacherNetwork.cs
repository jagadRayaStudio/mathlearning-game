using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Animarket
{
    public class TeacherNetwork : MonoBehaviourPunCallbacks
    {
        private void Start()
        {
            // You might want to keep the logic specific to the local player only
            if (photonView.IsMine)
            {
                // Set up for actions specific to the local player
                // For example: Handling UI interactions, etc.
            }

            // Additional logic can be added for both local and remote players
        }

        public void SignalQuestionsDone()
        {
            if (photonView.IsMine)
            {
                photonView.RPC("RPCQuestionsDone", RpcTarget.All);
            }
        }

        [PunRPC]
        private void RPCQuestionsDone()
        {
            if (!photonView.IsMine) return;

            // Do something when the teacher finishes creating questions
            // For example, load a summary screen
            PhotonNetwork.LoadLevel("Leaderboard");
        }
    }
}


/*public void openShopPanel()
{
    if (photonView.IsMine)
    {
        shopPanel.SetActive(true);
    }
}*/