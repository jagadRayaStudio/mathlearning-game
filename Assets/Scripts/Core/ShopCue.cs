using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animarket
{

    public class ShopCue : MonoBehaviour
    {
        [Header("Cue")]
        [SerializeField] private GameObject Cue;

        [Header("Shop Panel")]
        [SerializeField] public GameObject ShopPanel;

        private bool PlayerInRange;
        private ShopID shopID;
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

            ShopPanel.SetActive(false);
        }

        private void Update()
        {
            if (PlayerInRange)
            {
                Cue.SetActive(true);
                if (Interactions.GetInstance().IsInteracting)
                {
                    GetShopID();
                    ShopPanel.SetActive(true);
                }
            }
            else
            {
                Cue.SetActive(false);
            }
        }

        public int GetShopID()
        {
            ShopID ShopIDScript = GetComponent<ShopID>();
            if (ShopIDScript != null)
            {
                int currentShopID = ShopIDScript.shopID;
                Debug.Log("Shop ID is " + currentShopID);
                return currentShopID;
            }
            return 0;
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
    }
}