using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animarket
{

    public class DialogueTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject Cue;
        [SerializeField] public TextAsset inkJSON;

        private bool PlayerInRange;

        private void Awake()
        {
            PlayerInRange = false;
            Cue.SetActive(false);
        }

        private void Update()
        {
            if (PlayerInRange && !DialogueManager.GetInstance().DialogueIsPlaying)
            {
                Cue.SetActive(true);
                if (Interactions.GetInstance().IsInteracting)
                {
                    DialogueManager.GetInstance().StartDialogue(inkJSON);
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