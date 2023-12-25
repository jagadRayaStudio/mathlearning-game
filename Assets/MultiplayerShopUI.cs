using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Animarket
{
    public class MultiplayerShopUI : UIAnim
    {
        [SerializeField] GameObject shopItemParent;
        [SerializeField] Button shopItem;
        [SerializeField] private GameObject productListPanel;
        [SerializeField] private GameObject productListParent;
        [SerializeField] private GameObject productPrefab;


        public GameObject shopPanel;
        public Button closeButton;

        private MultiplayershopManager shopManager;

        private List<Button> shopItems = new List<Button>();

        private bool shopItemsInstantiated = false;

        protected override void Awake()
        {
            shopManager = FindObjectOfType<MultiplayershopManager>();
            productListPanel.SetActive(false);
            base.Awake();
        }

        public override void OnEnable()
        {
            if (!shopItemsInstantiated)
            {
                InstantiateShopItem();
                shopItemsInstantiated = true;
            }
            else
            {
                foreach (var shopItem in shopItems)
                {
                    shopItem.gameObject.SetActive(true);
                }
            }

            closeButton.onClick.AddListener(CloseUI);
            base.OnEnable();
        }

        public override void StartDisable()
        {
            foreach (var shopItem in shopItems)
            {
                shopItem.gameObject.SetActive(false);
            }
            base.StartDisable();
        }

        private void CloseUI()
        {
            shopPanel.SetActive(false);
        }

        void InstantiateShopItem()
        {
            shopItems.Clear();

            foreach (var shopInfo in shopManager.GetShopList())
            {
                Button _tempShop = Instantiate(shopItem, shopItemParent.transform);
                _tempShop.GetComponent<MultiplayerShop>().SetShop(shopInfo.shopName, shopInfo.shopIcon);
                _tempShop.onClick.AddListener(() => OpenProductPanel(shopInfo.products));
                _tempShop.gameObject.SetActive(true);
                shopItems.Add(_tempShop);
            }
        }

        void OpenProductPanel(List<Item> products)
        {
            productListPanel.SetActive(true);
            InstantiateProduct(products);
        }

        void InstantiateProduct(List<Item> products)
        {
            foreach (Transform child in productListParent.transform)
            {
                Destroy(child.gameObject);
            }

            foreach (var productInfo in products)
            {
                GameObject _tempProduct = Instantiate(productPrefab, productListParent.transform);
                _tempProduct.GetComponent<MultiplayerProduct>().SetProduct(productInfo);
            }
        }

    }
}
