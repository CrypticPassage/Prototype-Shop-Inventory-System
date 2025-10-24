using Enums;

namespace Handlers
{
    public interface IInventoryHandler
    {
        void InitializeInventory();
        void AddItem(EItemType type);
    }
}