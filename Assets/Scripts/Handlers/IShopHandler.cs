using UnityEngine;

namespace Handlers
{
    public interface IShopHandler
    {
        GameObject ShopContainer { get; }
        void InitializeShop();
    }
}