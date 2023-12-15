using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Animarket
{
    public class UIShop : UIAnim
    {
        public ShopManager shopManager;
        private ShopCue shopCue;

        //Game Object Reference
        public GameObject shopItemParent;
        public GameObject shopItem;
        public GameObject shopPanel;
        public GameObject tutorialPanel;
        public GameObject itemDescPanel;
        public GameObject buyingPanel;

        public Stock selectedItem;
        private List<GameObject> shopItems = new List<GameObject>();
        //private bool shopItemsInstantiated = false;


        //Button
        public Button closeButton;
        //public Button helpButton;



        protected override void Awake()
        {
            closeButton.onClick.AddListener(StartDisable);
            //helpButton.onClick.AddListener(OpenTutorialPanel);
            SetShopID();
            base.Awake();
        }

        public override void OnEnable()
        {
            base.OnEnable();
        }

        public void SetShopID()
        {
            ShopCue shopCue = GetComponent<ShopCue>();
            if(shopCue != null)
            {
                int currentShopID = shopCue.GetShopID();
                Debug.Log("Shop ID yang diteima UI adalah " + currentShopID);
            }
        }

        public override void StartDisable()
        {
            ClearItems();
            shopPanel.SetActive(false);
            base.StartDisable();
        }

        private void ClearItems()
        {
            foreach (var shopItem in shopItems)
            {
                Destroy(shopItem);
            }

            shopItems.Clear();
            selectedItem = default(Stock);
        }

        /*private void InstantiateShopItem()
        {
            ClearUI();

            foreach (Stock stock in currentShop.stock)
            {
                GameObject _tempShopItem = Instantiate(shopItem, shopItemParent.transform);
                _tempShopItem.GetComponent<ShopItem>().SetItem(stock);
                _tempShopItem.SetActive(false);
                shopItems.Add(_tempShopItem);
            }
        }
        */

        //private void OpenTutorialPanel()
        //

        private void ShowItemDescription()
        {
            itemDescPanel.SetActive(true);
        }

        private void HideDescriptionPanel()
        {
            itemDescPanel.SetActive(false);
        }

        private void PurchaseItem()
        {
            buyingPanel.SetActive(true);
        }

        public Stock GetSelectedItem()
        {
            return selectedItem;
        }
    }
}
