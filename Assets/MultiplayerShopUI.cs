using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Animarket
{
    public class MultiplayerShopUI : MonoBehaviour
    {
        [SerializeField] GameObject shopItemParent;
        [SerializeField] Button shopItem;
        public GameObject shopPanel;
        [SerializeField] private GameObject productListPanel;
        [SerializeField] private GameObject productListParent;
        [SerializeField] Button productPrefab;

        public Button closeButton1;
        public Button closeButton2;

        private Item selectedProduct;
        private MultiplayershopManager shopManager;
        private UIQuestion uiQuestion;


        private List<Button> shopItems = new List<Button>();

        private void Awake()
        {
            shopManager = FindObjectOfType<MultiplayershopManager>();
            productListPanel.SetActive(false);
        }

        private void Start()
        {
            uiQuestion = FindObjectOfType<UIQuestion>();
            InstantiateShopItem();
            closeButton1.onClick.AddListener(CloseUI1);
            closeButton2.onClick.AddListener(CloseUI2);
        }

        private void CloseUI1()
        {
            shopPanel.SetActive(false);
        }
        private void CloseUI2()
        {
            productListPanel.SetActive(false);
            shopPanel.SetActive(true);
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
            shopPanel.SetActive(false);
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
                Button _tempProduct = Instantiate(productPrefab, productListParent.transform);
                _tempProduct.GetComponent<MultiplayerProduct>().SetProduct(productInfo);
                _tempProduct.onClick.AddListener(() => SelectedProduct(productInfo));
            }
        }

        public void SelectedProduct(Item selectedProduct)
        {
            this.selectedProduct = selectedProduct;

            shopPanel.SetActive(false);
            productListPanel.SetActive(false);

            uiQuestion.SetSelectedProduct(selectedProduct);
        }

    }
}