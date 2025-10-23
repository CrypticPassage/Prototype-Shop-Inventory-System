using Enums;
using Models;

namespace Databases
{
    public interface IItemsDatabase
    {
        ItemVo GetItemDataByType(EItemType type);
    }
}