using DiscountManagerApp.Interfaces;
using System;
using System.Collections.Generic;

namespace DiscountManagerApp.Entities
{
    public class CustomerDiscountCalculatorFactory : ICustomerDiscountCalculatorFactory
    {
        private Dictionary<ECustomerType, ICustomerDiscountCalculatorV2> _dictCustomerDiscountCalculator;

        public CustomerDiscountCalculatorFactory(Dictionary<ECustomerType, ICustomerDiscountCalculatorV2> dictCustomerDiscountCalculator)
        {
            _dictCustomerDiscountCalculator = dictCustomerDiscountCalculator;
        }

        public ICustomerDiscountCalculatorV2 GetCustomerDiscountCalculatorConcreteType(ECustomerType customerType)
        {
            if (_dictCustomerDiscountCalculator.ContainsKey(customerType))
            {
                return _dictCustomerDiscountCalculator[customerType];
            }

            throw new NotImplementedException("CustomerDiscountCalculator type not implemented!");
        }
    }
}
