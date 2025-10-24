using Enums;
using Handlers.Impls;
using Listeners;
using Services.Impls;
using UnityEngine;

namespace Controllers.Impls
{
    public class GameController : MonoBehaviour, IGameController
    {
        [SerializeField] private ActionListeners _actionListeners;
        [SerializeField] private CurrencyService _currencyService;
        [SerializeField] private ShopHandler _shopHandler;
        [SerializeField] private InventoryHandler _inventoryHandler;

        private void OnEnable()
        {
            _actionListeners.OnItemBuy += OnItemBuy;
        }

        private void Start()
        {
            _currencyService.AddCurrency(50);
            _shopHandler.InitializeShop();
            _inventoryHandler.InitializeInventory();
        }
        
        private void OnDisable()
        {
            _actionListeners.OnItemBuy -= OnItemBuy;
        }

        private void OnItemBuy(EItemType type, float price)
        {
            if (!_currencyService.CheckAvailabilityToBuy(price))
                return;
            
            _currencyService.SubtractCurrency(price);
            _inventoryHandler.AddItem(type);
        }
    }
}