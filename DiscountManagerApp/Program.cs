using DiscountManagerApp;
using DiscountManagerApp.Entities;
using DiscountManagerApp.Interfaces;
using System;
using System.Collections.Generic;

namespace DiscountManagerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region Check Args
                if (args.Length != 3)
                    throw new ArgumentException("Must pass just 3 Arguments (amount:decimal customertype:int yearsOfSubscription:int)");

                if (decimal.TryParse(args[0], out decimal amount))
                {
                    if (amount < 0)
                        throw new ArgumentException("Amount parameter can't be negative number!");
                }
                else
                    throw new NotFiniteNumberException("Amount parameter is not a number");

                if (int.TryParse(args[1], out int customerType) == false)
                    throw new NotFiniteNumberException("Customer Type parameter is not a number");


                if (int.TryParse(args[2], out int yearsOfSubscription))
                {
                    if (yearsOfSubscription < 0)
                        throw new ArgumentException("LoyaltyYears parameter can't negative number!");
                }
                else
                    throw new NotFiniteNumberException("LoyaltyYears parameter is not a number");
                #endregion

                Dictionary<ECustomerType,ICustomerDiscountCalculatorV2> dictCustomerDiscountCalculator = new Dictionary<ECustomerType, ICustomerDiscountCalculatorV2>();
                dictCustomerDiscountCalculator.Add(ECustomerType.NOT_REGISTERED, new NotRegisteredCustomerDiscountCalculator());
                dictCustomerDiscountCalculator.Add(ECustomerType.REGISTERED, new RegisteredCustomerDiscountCalculator());
                dictCustomerDiscountCalculator.Add(ECustomerType.VALUABLE, new ValuableCustomerDiscountCalculator());
                dictCustomerDiscountCalculator.Add(ECustomerType.MOST_VALUABLE, new MostValuableCustomerDiscountCalculator());

                DiscountManager discountManager = new DiscountManager(new CustomerDiscountCalculatorFactory(dictCustomerDiscountCalculator));

                var result = discountManager.CalculateDiscountedAmount(amount, customerType, yearsOfSubscription);

                Console.WriteLine($"Discount for customer {customerType} is: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
