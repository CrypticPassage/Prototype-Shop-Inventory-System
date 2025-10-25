using Models;
using TMPro;
using UnityEngine;

namespace Items
{
    public class ShopItem : ABaseItemView
    {
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text priceText;
    
        public float Price { get; private set; }

        public override void SetData(ItemVo data)
        {
            base.SetData(data);
            nameText.text = data.Name;
            priceText.text = data.PriceToBuy.ToString();
            Price = data.PriceToBuy;
        }
    }
}