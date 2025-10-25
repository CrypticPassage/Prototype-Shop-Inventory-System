using Databases.Impls;
using Enums;
using Handlers.Impls;
using Listeners;
using Objects;
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
        [SerializeField] private BuildingsHandler _buildingsHandler;
        [SerializeField] private GameSettingsDatabase _gameSettingsDatabase;
        [SerializeField] private Button _openShopButton;

        private void OnEnable()
        {
            _actions.OnItemBuy += OnItemBuy;
            _actions.OnBuildingClick += OnBuildingClick;
        }

        private void Start()
        {
            _openShopButton.onClick.AddListener(OnOpenShopButton);
            
            _currencyService.AddCurrency(_gameSettingsDatabase.CurrencyAmountAtStart);
            _shopHandler.InitializeShop();
            _inventoryHandler.InitializeInventory();
            _buildingsHandler.InitializeBuildings();
        }
        
        private void OnDisable()
        {
            _actions.OnItemBuy -= OnItemBuy;
            _actions.OnBuildingClick -= OnBuildingClick;
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

        private void OnBuildingClick(Building building)
        {
            if (_inventoryHandler.ActiveItem == null ||
                !_inventoryHandler.IsItemCanBeUsedToBuilding(_inventoryHandler.ActiveItem, building))
                return;
            
            _currencyService.AddCurrency(_inventoryHandler.ActiveItem.PriceToSell); 
            _inventoryHandler.RemoveActiveItem();
        }
    }
}