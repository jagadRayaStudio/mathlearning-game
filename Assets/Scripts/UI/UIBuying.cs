using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Animarket
{
    public class UIBuying : MonoBehaviour
    {
        [SerializeField] Image itemIcon;
        [SerializeField] TMP_Text itemNameText;
        [SerializeField] TMP_Text costText;
        [SerializeField] TMP_Text desc;
        [SerializeField] TMP_InputField amountInput;
        [SerializeField] TMP_InputField totalInput;

        public static UIBuying Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void SetSelectedItem(Item selectedItem)
        {
            itemIcon.sprite = selectedItem.sprite;
            itemNameText.text = selectedItem.name;
            costText.text = selectedItem.cost.ToString();
            desc.text = selectedItem.itemdesc.ToString();
        }
    }
}
