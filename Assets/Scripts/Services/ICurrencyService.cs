namespace Services
{
    public interface ICurrencyService
    {
        bool CheckAvailabilityToBuy(float price);
        void AddCurrency(float price);
        void SubtractCurrency(float price);
    }
}