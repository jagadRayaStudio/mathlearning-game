using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Animarket
{
    public class ButtonClick : MonoBehaviour
    {
        public Button InteractButton;

        // Start is called before the first frame update
        void Start()
        {
            Button btn = InteractButton.GetComponent<Button>();
            btn.onClick.AddListener(TaskOnClick);
        }

        void TaskOnClick()
        {
            Debug.Log("You have clicked the button!");
        }
    }
}