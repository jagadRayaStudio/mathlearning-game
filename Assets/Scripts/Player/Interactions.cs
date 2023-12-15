using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animarket {

    public class Interactions : MonoBehaviour {

        private static Interactions instance;
        public bool IsInteracting { get; private set; }
        public bool IsClickTask { get; private set; }
        public bool IsClickShop { get; private set; }

        // Game Object
        [SerializeField] public GameObject taskPanel;
        [SerializeField] public GameObject shopPanel;
        
        private int currentShopID;

        private void Awake() {
            if (instance == null)
            {
                instance = this;
            }
            IsInteracting = false;
            taskPanel.SetActive(false);
            shopPanel.SetActive(false);
        }

        public static Interactions GetInstance() {
            return instance;
        }

        public void Interact()
        {
            IsInteracting = true;
        }

        public void NotInteract()
        {
            IsInteracting = false;
        }

        public bool OnInteracting()
        {
            return IsInteracting;
        }

        public void ClickTask()
        {
            taskPanel.SetActive(true);
        }

        public void ClickShop()
        {
            shopPanel.SetActive(true);
        }
    }
}