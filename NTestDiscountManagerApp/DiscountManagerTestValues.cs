using DiscountManagerApp;
using DiscountManagerApp.Entities;
using DiscountManagerApp.Interfaces;
using NTestDiscountManagerApp.LegacyApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace NTestDiscountManagerApp
{

    public class DiscountManagerTestValues
    {
        DiscountManager _discountManager;

        [SetUp]
        public void Setup()
        {
            Dictionary<ECustomerType, ICustomerDiscountCalculatorV2> dictCustomerDiscountCalculator = new Dictionary<ECustomerType, ICustomerDiscountCalculatorV2>();
            dictCustomerDiscountCalculator.Add(ECustomerType.NOT_REGISTERED, new NotRegisteredCustomerDiscountCalculator());
            dictCustomerDiscountCalculator.Add(ECustomerType.REGISTERED, new RegisteredCustomerDiscountCalculator());
            dictCustomerDiscountCalculator.Add(ECustomerType.VALUABLE, new ValuableCustomerDiscountCalculator());
            dictCustomerDiscountCalculator.Add(ECustomerType.MOST_VALUABLE, new MostValuableCustomerDiscountCalculator());
            _discountManager = new DiscountManager(new CustomerDiscountCalculatorFactory(dictCustomerDiscountCalculator));
        }

        [TestCase(85.0, 1, 1)]
        [TestCase(85.0, 1, 2)]
        [TestCase(85.0, 1, 3)]
        [TestCase(85.0, 1, 4)]
        [TestCase(85.0, 1, 5)]
        [TestCase(85.0, 1, 6)]
        public void Calculate_NotRegisteredCustomer_Amount85_SubscriptionYears_0_to_6(double amount, int customerType, int yearsOfSubscriptions)
        {
            //Arrange
            LegacyCalculator legacyCalculator = new LegacyCalculator();

            //Act
            var expected = legacyCalculator.Calculate(Convert.ToDecimal(amount), customerType, yearsOfSubscriptions);
            var result = _discountManager.CalculateDiscountedAmount(Convert.ToDecimal(amount), customerType, yearsOfSubscriptions);

            //Assert
            Assert.AreEqual(expected, result);
        }


        [TestCase(95.0, 2, 1)]
        [TestCase(95.0, 2, 2)]
        [TestCase(95.0, 2, 3)]
        [TestCase(95.0, 2, 4)]
        [TestCase(95.0, 2, 5)]
        [TestCase(95.0, 2, 6)]
        public void Calculate_RegisteredCustomer_Amount_95_SubscriptionYears_0_to_6(double amount, int customerType, int yearsOfSubscriptions)
        {
            //Arrange
            LegacyCalculator legacyCalculator = new LegacyCalculator();

            //Act
            var expected = legacyCalculator.Calculate(Convert.ToDecimal(amount), customerType, yearsOfSubscriptions);
            var result = _discountManager.CalculateDiscountedAmount(Convert.ToDecimal(amount), customerType, yearsOfSubscriptions);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase(75.0, 3, 1)]
        [TestCase(75.0, 3, 2)]
        [TestCase(75.0, 3, 3)]
        [TestCase(75.0, 3, 4)]
        [TestCase(75.0, 3, 5)]
        [TestCase(75.0, 3, 6)]
        public void Calculate_ValuableCustomer_Amount_75_SubscriptionYears_0_to_6(double amount, int customerType, int yearsOfSubscriptions)
        {
            //Arrange
            LegacyCalculator legacyCalculator = new LegacyCalculator();

            //Act
            var expected = legacyCalculator.Calculate(Convert.ToDecimal(amount), customerType, yearsOfSubscriptions);
            var result = _discountManager.CalculateDiscountedAmount(Convert.ToDecimal(amount), customerType, yearsOfSubscriptions);

            //Assert
            Assert.AreEqual(expected, result);
        }


        [TestCase(44.5, 4, 1)]
        [TestCase(44.5, 4, 2)]
        [TestCase(44.5, 4, 3)]
        [TestCase(44.5, 4, 4)]
        [TestCase(44.5, 4, 5)]
        [TestCase(44.5, 4, 6)]
        public void Calculate_MostValuableCustomer_Amount_44_5_SubscriptionYears_0_to_6(double amount, int customerType, int yearsOfSubscriptions)
        {
            //Arrange
            LegacyCalculator legacyCalculator = new LegacyCalculator();

            //Act
            var expected = legacyCalculator.Calculate(Convert.ToDecimal(amount), customerType, yearsOfSubscriptions);
            var result = _discountManager.CalculateDiscountedAmount(Convert.ToDecimal(amount), customerType, yearsOfSubscriptions);

            //Assert
            Assert.AreEqual(expected, result);

        }
    }





}