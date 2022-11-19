namespace DiscountManagerApp.Entities
{
    public class MostValuableCustomerDiscountCalculator : BaseCustomerDiscountCalculator
    {
        public const decimal DISCOUNT_FOR_MOST_VALUABLE = (decimal)50 / 100; //50%

        public override decimal CalculateDiscountedAmount(decimal amount,int yearsOfSubscriptions)
        {
            decimal customAmountDiscount = amount - CalculateCustomAmountDiscount(amount, DISCOUNT_FOR_MOST_VALUABLE);
            return customAmountDiscount - CalculateLoyaltyDiscount(yearsOfSubscriptions) * customAmountDiscount;
        }
    }
}
