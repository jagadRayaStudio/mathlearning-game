using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animarket
{

    public class OpenMultiplayer : MonoBehaviour
    {
        [SerializeField] private GameObject Cue;
        [SerializeField] private GameObject pickRolePanel;

        private bool PlayerInRange;

        private void Awake()
        {
            PlayerInRange = false;
            Cue.SetActive(false);
            pickRolePanel.SetActive(false);
        }

        private void Update()
        {
            if (PlayerInRange)
            {
                Cue.SetActive(true);
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