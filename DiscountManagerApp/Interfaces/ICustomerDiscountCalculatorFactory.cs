using DiscountManagerApp.Entities;

namespace DiscountManagerApp.Interfaces
{
    public interface ICustomerDiscountCalculatorFactory
    {
        ICustomerDiscountCalculatorV2 GetCustomerDiscountCalculatorConcreteType(ECustomerType customerType);
    }
}
