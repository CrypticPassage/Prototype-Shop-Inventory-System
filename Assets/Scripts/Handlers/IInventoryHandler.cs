using Enums;
using Items;
using Objects;

namespace Handlers
{
    public interface IInventoryHandler
    {
        InventoryItem ActiveItem { get; }
        void InitializeInventory();
        void AddItem(InventoryItem item, EItemType type);
        InventoryItem GetItemFromCollectionToAdd(EItemType type);
        void RemoveActiveItem();
        void DeactivateActiveItem();
        bool IsItemCanBeUsedToBuilding(InventoryItem item, Building building);
    }
}