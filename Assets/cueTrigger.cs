using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animarket
{

    public class CueTrigger : MonoBehaviour
    {
        public static CueTrigger instance;

        [SerializeField] private GameObject Cue;
        [SerializeField] public GameObject pickRolePanel;

        private bool PlayerInRange;

        private void Awake()
        {
            instance = this;
            PlayerInRange = false;
            Cue.SetActive(false);
            pickRolePanel.SetActive(false);
        }

        public static CueTrigger GetInstance()
        {
            return instance;
        }

        private void Update()
        {
            if (PlayerInRange)
            {
                Cue.SetActive(true);
                if (Interactions.GetInstance().IsInteracting)
                {
                    pickRolePanel.SetActive(true);
                }
            }
            else
            {
                Cue.SetActive(false);
            }
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