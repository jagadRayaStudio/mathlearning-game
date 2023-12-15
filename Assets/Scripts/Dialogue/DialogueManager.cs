using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;

namespace Animarket
{

    public class DialogueManager : MonoBehaviour
    {
        private static DialogueManager instance;

        private const string SPEAKER_TAG = "speaker";
        private const string ICON_TAG = "icon";


        [Header("Dialogue UI")]
        [SerializeField] private GameObject DialoguePanel;
        [SerializeField] private TextMeshProUGUI DialogueText;
        [SerializeField] private TextMeshProUGUI displayNameText;
        [SerializeField] private Animator CharIcon;

        private Story currenstory;
        public bool DialogueIsPlaying { get; private set; }
        public Button nextButton;

        private void Awake()
        {
            if (instance != null){ }
            instance = this;
        }

        public static DialogueManager GetInstance()
        {
            return instance;
        }

        private void Start()
        {
            DialogueIsPlaying = false;
            DialoguePanel.SetActive(false);
            nextButton.onClick.AddListener(nextstory);
        }

        private void Update()
        {
            if (!DialogueIsPlaying)
            {
                return;
            }
        }

        public void StartDialogue(TextAsset inkJSON)
        {
            currenstory = new Story(inkJSON.text);
            DialogueIsPlaying = true;
            DialoguePanel.SetActive(true);

            nextstory();
        }


        private void nextstory()
        {
            if (currenstory.canContinue)
            {
                DialogueText.text = currenstory.Continue();
                HandleTags(currenstory.currentTags);
            }

            else
            {
                EndDialogue();
            }
        }

        private void HandleTags(List<string> currentTags)
        {
            foreach(string tag in currentTags)
            {
                string[] splitTag = tag.Split(':');
                if (splitTag.Length != 2)
                {
                    Debug.LogError("Tag could not be appropriately parsed: " + tag);
                }
                string tagKey = splitTag[0].Trim();
                string tagValue = splitTag[1].Trim();

            switch (tagKey)
                {
                    case SPEAKER_TAG:
                        displayNameText.text = tagValue;
                        break;                        
                    case ICON_TAG:
                        CharIcon.Play(tagValue);
                        break;
                    default:
                        Debug.LogWarning("Tag came in but not currently being handled: " + tag);
                        break;
                }
            }
        }

        private void EndDialogue()
        {
            DialogueIsPlaying = false;
            DialoguePanel.SetActive(false);
            DialogueText.text = "";
        }

    }
}
