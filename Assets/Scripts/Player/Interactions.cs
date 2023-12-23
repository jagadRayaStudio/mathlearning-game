using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animarket {

    public class Interactions : MonoBehaviour {

        private static Interactions instance;
        public bool IsInteracting { get; private set; }
        public bool IsInteractingEmak { get; private set; }

        // Game Object
        [SerializeField] public GameObject levelPanel;

        private void Awake() {
            if (instance == null)
            {
                instance = this;
            }
            IsInteracting = false;
            levelPanel.SetActive(false);
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

        public void InteractingEmak()
        {
            levelPanel.SetActive(true);
        }
    }
}