using System;
using Enums;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class ItemVo
    {
        public EItemType Type;
        public Sprite Icon;
        public string Name;
        public string PriceToBuyText;
        public string PriceToSellText;
        public float PriceToBuy;
        public float PriceToSell;
    }
}