using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Animarket
{
    public class StudentMechanicsUI : MonoBehaviour
    {
        [SerializeField] public GameObject shopPanel;
        [SerializeField] GameObject shopItemParent;
        [SerializeField] Button shopItem;
        
        [SerializeField] private GameObject productPanel;
        [SerializeField] private GameObject productListParent;
        [SerializeField] Button productPrefab;

        [SerializeField] public GameObject mechanicPanel;
        [SerializeField] private UIMechanic uiMechanic;

        private Item selectedProduct;
        private MultiplayershopManager shopManager;


        private List<Button> shopItems = new List<Button>();

        private void Awake()
        {
            shopManager = FindObjectOfType<MultiplayershopManager>();
            productPanel.SetActive(false);
            mechanicPanel.SetActive(false);
            shopPanel.SetActive(true);

        }

        private void Start()
        {
            InstantiateShopItem();
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
            productPanel.SetActive(true);
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
            productPanel.SetActive(false);
            mechanicPanel.SetActive(true);

            uiMechanic.SetSelectedProduct(selectedProduct);
        }

    }
}