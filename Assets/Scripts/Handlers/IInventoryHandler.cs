using Enums;
using Items;

namespace Handlers
{
    public interface IInventoryHandler
    {
        void InitializeInventory();
        void AddItem(InventoryItem item, EItemType type);
        InventoryItem GetItemFromCollectionToAdd(EItemType type);
        void RemoveActiveItem();
        void DeactivateActiveItem();
    }
}