namespace DiscountManagerApp.Interfaces
{
    public interface ICustomerDiscountCalculatorV2
    {
        decimal CalculateCustomAmountDiscount(decimal amount, decimal personalPercentage);
        decimal CalculateLoyaltyDiscount(int yearsOfSubscriptions);
        decimal CalculateDiscountedAmount(decimal amount, int yearsOfSubscription);
    }
}
