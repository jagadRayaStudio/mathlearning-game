using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animarket
{
    public class ShopCue : MonoBehaviour
    {
        [SerializeField] private GameObject Cue;
        [SerializeField] public GameObject shopPanel;

        private bool PlayerInRange;
        private ShopManager shopManager;

        private static ShopCue instance;

        public static ShopCue GetInstance()
        {
            return instance;
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            PlayerInRange = false;
            Cue.SetActive(false);

            shopManager = GetComponent<ShopManager>();
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.tag == "Player")
            {
                PlayerInRange = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            if (collider.gameObject.tag == "Player")
            {
                PlayerInRange = false;
            }
        }

        private void Update()
        {
            if (PlayerInRange)
            {
                Cue.SetActive(true);
                if (Interactions.GetInstance().IsInteracting)
                {
                    shopPanel.SetActive(true);
                    shopManager.OpenShop();
                }
            }
            else
            {
                Cue.SetActive(false);
            }
        }
    }
}
