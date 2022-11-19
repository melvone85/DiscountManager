namespace DiscountManagerApp.Interfaces
{
    public interface ICustomerDiscountCalculator
    {
        decimal CalculateDiscountedAmount(decimal amount, int customerType, int yearsOfSubscription);
    }
}
