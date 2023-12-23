using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animarket
{

    public class DialogueTrigger : MonoBehaviour
    {
        public static DialogueTrigger instance;

        [SerializeField] private GameObject Cue;
        [SerializeField] public GameObject loadPanel;
        [SerializeField] public TextAsset inkJSON;

        private bool PlayerInRange;

        private void Awake()
        {
            instance = this;
            PlayerInRange = false;
            Cue.SetActive(false);
        }

        public static DialogueTrigger GetInstance()
        {
            return instance;
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