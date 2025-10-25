using Collections;
using Databases.Impls;
using Enums;
using Items;
using Listeners;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Handlers.Impls
{
    public class ShopHandler : ABaseItemHandler<ShopItem>, IShopHandler
    {
        [SerializeField] private Actions _actions;
        [SerializeField] private GameObject _shopContainer;
        [SerializeField] private ShopItemsCollection _shopItemsCollection;
        [SerializeField] private TMP_Text _activeItemDescriptionText;
        [SerializeField] private ItemsDatabase _itemsDatabase;
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _buyButton;
        
        public GameObject ShopContainer => _shopContainer;
        
        public void InitializeShop()
        {
            _closeButton.onClick.AddListener(OnCloseButtonClick);
            _buyButton.onClick.AddListener(OnBuyButtonClick);
            _activeItemDescriptionText.gameObject.SetActive(false);
            
            InitializeItems();
        }

        private void InitializeItems()
        {
            for (var i = 0; i < _itemsDatabase.Items.Length; i++)
            {
                if (_itemsDatabase.Items[i].Type == EItemType.None)
                    continue;
                
                var item = _shopItemsCollection.Items[i];
                
                item.SetData(_itemsDatabase.Items[i]);
                item.ClickButton.onClick.AddListener(() => OnItemClick(item));
            }
        }

        protected override void OnItemClick(ShopItem item)
        {
            if (_activeItem == item)
            {
                _activeItem.ChangeItemActivity();
                _activeItemDescriptionText.gameObject.SetActive(false);
                _activeItem = null;
                
                return;
            }
            
            _activeItem?.ChangeItemActivity();
            
            item.ChangeItemActivity();
            _activeItemDescriptionText.text = _itemsDatabase.GetItemDataByType(item.Type).Description;
            _activeItemDescriptionText.gameObject.SetActive(true);
            _activeItem = item;
        }

        private void OnCloseButtonClick()
        {
            _shopContainer.gameObject.SetActive(false);

            if (_activeItem == null)
                return;
            
            _activeItem.ChangeItemActivity();
            _activeItemDescriptionText.gameObject.SetActive(false);
            _activeItem = null;
        }

        private void OnBuyButtonClick()
        {
            if (_activeItem == null)
                return;
            
            _actions.OnItemBuy?.Invoke(_activeItem.Type, _activeItem.Price);
        }
    }
}