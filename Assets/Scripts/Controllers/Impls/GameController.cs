using Handlers.Impls;
using UnityEngine;

namespace Controllers.Impls
{
    public class GameController : MonoBehaviour, IGameController
    {
        [SerializeField] private ShopHandler _shopHandler;
        
        private void Start()
        {
            _shopHandler.InitializeShop();
        }
    }
}