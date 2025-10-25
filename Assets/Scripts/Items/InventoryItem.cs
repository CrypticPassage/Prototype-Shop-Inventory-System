using Enums;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Items
{
    public class InventoryItem : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private Image activeImage;
        [SerializeField] private TMP_Text amountText;
        [SerializeField] private Button clickButton;
        
        private EItemType _type;
        private float _priceToSell;
        private int _amount;

        public TMP_Text AmountText => amountText;
        public Button ClickButton => clickButton;
        
        public EItemType Type
        {
            get => _type;
            set => _type = value;
        }
        
        public float PriceToSell
        {
            get => _priceToSell;
            set => _priceToSell = value;
        }
        
        public int Amount
        {
            get => _amount;
            set => _amount = value;
        }
        
        public void SetData(ItemVo data)
        {
            icon.sprite = data.Icon;
            
            _type = data.Type;
            _priceToSell = data.PriceToSell;
        }
        
        public void ChangeItemActivity() 
            => activeImage.gameObject.SetActive(!activeImage.gameObject.activeSelf);
    }
}