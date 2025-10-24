using Enums;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Items
{
    public class ShopItem : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private Image activeImage;
        [SerializeField] private TMP_Text name;
        [SerializeField] private TMP_Text priceToBuyText;
        [SerializeField] private Button clickButton;
        
        private EItemType _type;
        private float _price;
        
        public Button ClickButton => clickButton;
        public float Price
        {
            get => _price;
            set => _price = value;
        }
        
        public EItemType Type
        {
            get => _type;
            set => _type = value;
        }
        
        public void SetData(ItemVo data)
        {
            icon.sprite = data.Icon;
            name.text = data.Name;
            priceToBuyText.text = data.PriceToBuyText;
            
            _price = data.PriceToBuy;
            _type = data.Type;
        }

        public void SetItemActivity() 
            => activeImage.gameObject.SetActive(!activeImage.gameObject.activeSelf);
    }
}