using Items;
using UnityEngine;

namespace Collections
{
    public class ShopItemsCollection : MonoBehaviour
    {
        [SerializeField] private ShopItem[] _shopItems;

        public ShopItem[] ShopItems => _shopItems;
    }
}