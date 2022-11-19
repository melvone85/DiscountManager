using DiscountManagerApp.Interfaces;

namespace DiscountManagerApp.Entities
{
    public enum ECustomerType
    {
        NOT_REGISTERED = 1,
        REGISTERED = 2,
        VALUABLE = 3,
        MOST_VALUABLE = 4
    }

    public abstract class BaseCustomerDiscountCalculator : ICustomerDiscountCalculatorV2
    {
        public const decimal MAX_LOYALTY_DISCOUNT = (decimal)5 / 100;
        public const int MIN_YEAR_FOR_MAX_LOYALTY_DISCOUNT = 5;

        public abstract decimal CalculateDiscountedAmount(decimal amount, int yearsOfSubscriptions);

        public decimal CalculateCustomAmountDiscount(decimal amount,decimal customDiscountForSubscriptionLevel)
        {
            return (customDiscountForSubscriptionLevel * amount);
        }

        public decimal CalculateLoyaltyDiscount(int yearsOfSubscriptions)
        {
           return yearsOfSubscriptions > MIN_YEAR_FOR_MAX_LOYALTY_DISCOUNT ? MAX_LOYALTY_DISCOUNT : (decimal)yearsOfSubscriptions / 100;
        }
    }
}
