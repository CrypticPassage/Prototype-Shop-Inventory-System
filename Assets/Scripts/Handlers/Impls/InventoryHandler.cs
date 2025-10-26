using System.Linq;
using Collections;
using Databases.Impls;
using Enums;
using Items;
using Objects;
using UnityEngine;

namespace Handlers.Impls
{
    /// <summary>
    /// This Handler corresponds to the inventory logic & gives methods to operate with him.
    /// </summary>
    public class InventoryHandler : ABaseItemHandler<InventoryItem>, IInventoryHandler
    {
        [SerializeField] private InventoryItemsCollection _inventoryItemsCollection;
        [SerializeField] private ItemsDatabase _itemsDatabase;
        
        public void InitializeInventory()
        {
            InitializeItems();
        }

        public void AddItem(InventoryItem item, EItemType type)
        {
            item.Amount += 1;
            item.AmountText.text = item.Amount.ToString();
            item.SetData(_itemsDatabase.GetItemDataByType(type));
            item.AmountText.gameObject.SetActive(true);
        }

        public InventoryItem GetItemFromCollectionToAdd(EItemType type)
        {
            foreach (var item in _inventoryItemsCollection.Items)
            {
                if (item.Type == type)
                    return item;
            }

            return _inventoryItemsCollection.Items.FirstOrDefault(item => item.Type == EItemType.None);
        }
        
        public void RemoveActiveItem()
        {
            if (_activeItem.Amount <= 0)
                return;

            _activeItem.Amount -= 1;
            _activeItem.AmountText.text = _activeItem.Amount.ToString();

            if (_activeItem.Amount > 0) 
                return;
            
            _activeItem.SetData(_itemsDatabase.GetItemDataByType(EItemType.None));
            _activeItem.AmountText.gameObject.SetActive(false);
        }

        public void DeactivateActiveItem()
        {
            if (_activeItem == null)
                return;
            
            _activeItem.ChangeItemActivity();
            _activeItem = null;
        }

        public bool IsItemCanBeUsedToBuilding(InventoryItem item, Building building)
        {
            foreach (var type in building.AcceptableItemTypes)
                if (type == item.Type)
                    return true;

            return false;
        }
        
        private void InitializeItems()
        {
            foreach (var item in _inventoryItemsCollection.Items)
            {
                item.SetData(_itemsDatabase.GetItemDataByType(EItemType.None));
                item.AmountText.gameObject.SetActive(false);
                
                item.ClickButton.onClick.AddListener(() => OnItemClick(item));
            }
        }
    }
}