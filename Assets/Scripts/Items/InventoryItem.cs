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
        
        private int _amount;
        private EItemType _type;

        public Button ClickButton => clickButton;
        
        public int Amount
        {
            get => _amount;
            set => _amount = value;
        }
        
        public EItemType Type
        {
            get => _type;
            set => _type = value;
        }
        
        public void SetData(ItemVo data)
        {
            icon.sprite = data.Icon;
            
            _type = data.Type;
        }

        public void SetAmountVisibility(bool isVisible)
        {
            amountText.text = _amount.ToString();
            amountText.gameObject.SetActive(isVisible);
        }

        public void SetItemActivity() 
            => activeImage.gameObject.SetActive(!activeImage.gameObject.activeSelf);
    }
}