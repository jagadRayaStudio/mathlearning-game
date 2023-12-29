using Photon.Pun;
using UnityEngine;

namespace Animarket
{
    public class MultiplayerPanelManager : MonoBehaviourPunCallbacks
    {
        public GameObject masterPanel;
        public GameObject clientPanel;
        public GameObject loadingPanel;

        void Start()
        {
            masterPanel.SetActive(false);
            clientPanel.SetActive(false);
            loadingPanel.SetActive(false);

            if (PhotonNetwork.IsMasterClient)
            {
                masterPanel.SetActive(true);
            }
            else
            {
                loadingPanel.SetActive(true);
            }
        }

        [PunRPC]
        public void startGame()
        {
            masterPanel.SetActive(false);
            clientPanel.SetActive(false);
            loadingPanel.SetActive(false);

            if (PhotonNetwork.IsMasterClient)
            {
                loadingPanel.SetActive(true);

                photonView.RPC("ShowClientPanel", RpcTarget.Others);
            }
            else
            {
                clientPanel.SetActive(true);
            }
        }

        [PunRPC]
        public void ShowClientPanel()
        {
            clientPanel.SetActive(true);
        }
    }
}