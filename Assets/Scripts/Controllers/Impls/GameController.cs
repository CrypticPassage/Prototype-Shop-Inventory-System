using Databases.Impls;
using Enums;
using Handlers.Impls;
using Listeners;
using Services.Impls;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.Impls
{
    public class GameController : MonoBehaviour, IGameController
    {
        [SerializeField] private Actions _actions;
        [SerializeField] private CurrencyService _currencyService;
        [SerializeField] private ShopHandler _shopHandler;
        [SerializeField] private InventoryHandler _inventoryHandler;
        [SerializeField] private GameSettingsDatabase _gameSettingsDatabase;
        [SerializeField] private Button _openShopButton;

        private void OnEnable()
        {
            _actions.OnItemBuy += OnItemBuy;
            _actions.OnItemUse += OnItemUse;
        }

        private void Start()
        {
            _openShopButton.onClick.AddListener(OnOpenShopButton);
            
            _currencyService.AddCurrency(_gameSettingsDatabase.CurrencyAmountAtStart);
            _shopHandler.InitializeShop();
            _inventoryHandler.InitializeInventory();
        }
        
        private void OnDisable()
        {
            _actions.OnItemBuy -= OnItemBuy;
            _actions.OnItemUse -= OnItemUse;
        }

        private void OnOpenShopButton()
        {
            _inventoryHandler.DeactivateActiveItem();
            _shopHandler.ShopContainer.gameObject.SetActive(true);
        }

        private void OnItemBuy(EItemType type, float price)
        {
            if (!_currencyService.CheckAvailabilityToBuy(price))
                return;

            var item = _inventoryHandler.GetItemFromCollectionToAdd(type);

            if (item == null)
                return;
            
            _currencyService.SubtractCurrency(price);
            _inventoryHandler.AddItem(item, type);
        }

        private void OnItemUse(EItemType type, float price)
        {
            _currencyService.AddCurrency(price);
            _inventoryHandler.RemoveActiveItem();
        }
    }
}