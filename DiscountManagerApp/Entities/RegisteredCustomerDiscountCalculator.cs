namespace DiscountManagerApp.Entities
{
    public class RegisteredCustomerDiscountCalculator : BaseCustomerDiscountCalculator
    {
        public const decimal DISCOUNT_FOR_REGISTERED = (decimal)10 / 100; //10%

        public override decimal CalculateDiscountedAmount(decimal amount, int yearsOfSubscriptions)
        {
            decimal customAmountDiscount = amount - CalculateCustomAmountDiscount(amount, DISCOUNT_FOR_REGISTERED);
            return customAmountDiscount - CalculateLoyaltyDiscount(yearsOfSubscriptions) * customAmountDiscount;
        }
    }
}
