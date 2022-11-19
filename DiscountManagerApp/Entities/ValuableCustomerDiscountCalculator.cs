namespace DiscountManagerApp.Entities
{
    public class ValuableCustomerDiscountCalculator : BaseCustomerDiscountCalculator
    {
        public const decimal DISCOUNT_FOR_VALUABLE = (decimal)70 / 100; //70%

        public override decimal CalculateDiscountedAmount(decimal amount,int yearsOfSubscriptions)
        {
            decimal customAmountDiscount = CalculateCustomAmountDiscount(amount, DISCOUNT_FOR_VALUABLE);
            return customAmountDiscount - CalculateLoyaltyDiscount(yearsOfSubscriptions) * customAmountDiscount;
        }
    }
}
