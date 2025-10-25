using Models;
using TMPro;
using UnityEngine;

namespace Items
{
    public class InventoryItem : ABaseItemView
    {
        [SerializeField] private TMP_Text amountText;

        public TMP_Text AmountText => amountText;
        
        public float PriceToSell { get; private set; }
        public int Amount { get; set; }

        public override void SetData(ItemVo data)
        {
            base.SetData(data);
            PriceToSell = data.PriceToSell;
        }
    }
}