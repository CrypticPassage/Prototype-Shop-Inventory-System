using Collections;
using Databases.Impls;
using Items;
using Services;
using UnityEngine;
using UnityEngine.UI;

namespace Handlers.Impls
{
    public class ShopHandler : MonoBehaviour, IShopHandler
    {
        [SerializeField] private GameObject _shopContainer;
        [SerializeField] private ShopItemsCollection _shopItemsCollection;
        [SerializeField] private ItemsDatabase _itemsDatabase;
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _buyButton;
        
        private ShopItem _activeItem;
        
        public void InitializeShop()
        {
            _closeButton.onClick.AddListener(() => _shopContainer.gameObject.SetActive(false));
            _buyButton.onClick.AddListener(OnBuyButtonClick);
            
            InitializeItems();
        }

        private void InitializeItems()
        {
            for (var i = 0; i < _shopItemsCollection.ShopItems.Length; i++)
            {
                var item = _shopItemsCollection.ShopItems[i];
                
                item.SetData(_itemsDatabase.Items[i]);
                item.ClickButton.onClick.AddListener(() => OnItemClick(item));
            }
        }

        private void OnItemClick(ShopItem item)
        {
            if (_activeItem == item)
            {
                _activeItem.SetItemActivity();
                _activeItem = null;
                
                return;
            }
            
            if (_activeItem != null)
                _activeItem.SetItemActivity();
            
            item.SetItemActivity();
            _activeItem = item;
        }

        private void OnBuyButtonClick()
        {
            // TODO
        }
    }
}