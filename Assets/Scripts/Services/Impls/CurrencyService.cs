using TMPro;
using UnityEngine;

namespace Services.Impls
{
    /// <summary>
    /// This Service corresponds to the currency logic & gives methods to operate with currency amount.
    /// </summary>
    public class CurrencyService : MonoBehaviour, ICurrencyService
    {
        [SerializeField] private TMP_Text _currencyAmountText;

        private float _amount;

        public bool CheckAvailabilityToBuy(float price)
        {
            return _amount >= price;
        }

        public void AddCurrency(float price)
        {
            _amount += price;
            SetCurrencyAmountText();
        }
        
        public void SubtractCurrency(float price)
        {
            _amount -= price;
            SetCurrencyAmountText();
        }
        
        private void SetCurrencyAmountText() 
            => _currencyAmountText.text = _amount.ToString();
    }
}