using Items;
using UnityEngine;

namespace Collections
{
    public class InventoryItemsCollection : MonoBehaviour
    {
        [SerializeField] private InventoryItem[] _inventoryItems;

        public InventoryItem[] InventoryItems => _inventoryItems;
    }
}