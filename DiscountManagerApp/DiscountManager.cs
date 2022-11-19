using DiscountManagerApp.Entities;
using DiscountManagerApp.Interfaces;
using System;

namespace DiscountManagerApp
{
    public class DiscountManager : ICustomerDiscountCalculator
    {
        ICustomerDiscountCalculatorFactory _customerDiscountCalculatorFactory;
        public DiscountManager(ICustomerDiscountCalculatorFactory customerDiscountCalculatorFactory)
        {
            _customerDiscountCalculatorFactory = customerDiscountCalculatorFactory;
        }

        public decimal CalculateDiscountedAmount(decimal amount, int customerType, int yearsOfSubscription)
        {
            if (amount < 0)
                throw new ArgumentException("Amount can't be less then 0.");

            if (yearsOfSubscription < 0)
                throw new ArgumentException("Subscription years can't be less then 0.");

            var customerFactory = _customerDiscountCalculatorFactory.GetCustomerDiscountCalculatorConcreteType((ECustomerType)customerType);

            return customerFactory.CalculateDiscountedAmount(amount,yearsOfSubscription);
        }
    }
}
