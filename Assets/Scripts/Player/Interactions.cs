using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animarket {

    public class Interactions : MonoBehaviour {

        private static Interactions instance;
        public bool IsInteracting { get; private set; }


        private void Awake() {
            if (instance == null)
            {
                instance = this;
            }
            IsInteracting = false;
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
    }
}