namespace DiscountManagerApp.Entities
{
    public class NotRegisteredCustomerDiscountCalculator : BaseCustomerDiscountCalculator
    {
        public override decimal CalculateDiscountedAmount(decimal amount, int yearsOfSubscriptions)
        {
            return amount;
        }
    }
}
