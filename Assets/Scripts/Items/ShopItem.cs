using Enums;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Items
{
    public class ShopItem : MonoBehaviour
    {
        [SerializeField] private Image iconImage;
        [SerializeField] private Image activeImage;
        [SerializeField] private TMP_Text name;
        [SerializeField] private TMP_Text priceText;
        [SerializeField] private Button clickButton;
        
        private EItemType _type;
        private float _price;
        
        public Button ClickButton => clickButton;
        
        public EItemType Type
        {
            get => _type;
            set => _type = value;
        }
        
        public float Price
        {
            get => _price;
            set => _price = value;
        }
        
        public void SetData(ItemVo data)
        {
            iconImage.sprite = data.Icon;
            name.text = data.Name;
            priceText.text = data.PriceToBuy.ToString();
            
            _price = data.PriceToBuy;
            _type = data.Type;
        }

        public void ChangeItemActivity() 
            => activeImage.gameObject.SetActive(!activeImage.gameObject.activeSelf);
    }
}