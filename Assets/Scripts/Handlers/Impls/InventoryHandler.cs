using System.Linq;
using Collections;
using Databases.Impls;
using Enums;
using Items;
using UnityEngine;

namespace Handlers.Impls
{
    public class InventoryHandler : MonoBehaviour, IInventoryHandler
    {
        [SerializeField] private InventoryItemsCollection _inventoryItemsCollection;
        [SerializeField] private ItemsDatabase _itemsDatabase;
        
        private InventoryItem _activeItem;
        
        public void InitializeInventory()
        {
           InitializeItems();
        }

        public void AddItem(EItemType type)
        {
            var item = GetItemFromCollectionToAdd(type);

            if (item == null)
                return;
            
            item.Amount += 1;
            item.SetData(_itemsDatabase.GetItemDataByType(type));
            item.SetAmountVisibility(true);
        }

        private void InitializeItems()
        {
            foreach (var item in _inventoryItemsCollection.InventoryItems)
            {
                item.SetData(_itemsDatabase.GetItemDataByType(EItemType.None));
                item.SetAmountVisibility(false);
                
                item.ClickButton.onClick.AddListener(() => OnItemClick(item));
            }
        }
        
        private void OnItemClick(InventoryItem item)
        {
            if (_activeItem == item)
            {
                _activeItem.SetItemActivity();
                _activeItem = null;
                
                return;
            }

            _activeItem?.SetItemActivity();

            item.SetItemActivity();
            _activeItem = item;
        }

        private InventoryItem GetItemFromCollectionToAdd(EItemType type)
        {
            foreach (var item in _inventoryItemsCollection.InventoryItems)
            {
                if (item.Type == type)
                    return item;
            }

            return _inventoryItemsCollection.InventoryItems.FirstOrDefault(item => item.Type == EItemType.None);
        }
    }
}