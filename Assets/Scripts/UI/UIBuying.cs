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
        [SerializeField] TMP_Text amountText;
        [SerializeField] TMP_InputField priceInputField;
        [SerializeField] Button increaseAmountButton;
        [SerializeField] Button decreaseAmountButton;

        private BuyingManager buyingManager;

        private void Start()
        {
            buyingManager = GetComponentInParent<BuyingManager>();
        }
    }
}
