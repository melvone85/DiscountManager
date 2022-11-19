using DiscountManagerApp;
using DiscountManagerApp.Entities;
using DiscountManagerApp.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace NTestDiscountManagerApp
{

    public class DiscountManagerTestValuesV2
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

        #region MultiData Test for NotRegisteredCustomerDiscountCalculator Amount:10m YearsOfSubscriptions From: Negative to 6 years
        private static IEnumerable<TestCaseData> AddCasesForNotRegisteredCustomer()
        {
            yield return new TestCaseData(10.0m, 1, 0, 10.0m);
            yield return new TestCaseData(10.0m, 1, 6, 10.0m);
        }
        [Test, TestCaseSource("AddCasesForNotRegisteredCustomer")]
        public void CalculateDiscountedAmount_When_AmountIs10andCustomerTypeIsNotRegisteredAndSubscriptionYearsFrom0And6Years_Then_decimalExpectedResult(decimal amount, int customerType, int yearsOfSubscriptions, decimal expectedResult)
        {
            //Arrange
            var result = _discountManager.CalculateDiscountedAmount(amount, customerType, yearsOfSubscriptions);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
        #endregion

        #region MultiData Test for RegisteredCustomerDiscountCalculator Amount:10m YearsOfSubscriptions From: 0 to 6 years
        private static IEnumerable<TestCaseData> AddCasesForRegisteredCustomer()
        {
            yield return new TestCaseData(10.0m, 2, 0, 9m);
            yield return new TestCaseData(10.0m, 2, 1, 8.91m);
            yield return new TestCaseData(10.0m, 2, 2, 8.82m);
            yield return new TestCaseData(10.0m, 2, 3, 8.73m);
            yield return new TestCaseData(10.0m, 2, 4, 8.64m);
            yield return new TestCaseData(10.0m, 2, 5, 8.55m);
            yield return new TestCaseData(10.0m, 2, 6, 8.55m);
        }


        [Test, TestCaseSource("AddCasesForRegisteredCustomer")]
        public void CalculateDiscountedAmount_When_AmountIs10andCustomerTypeIsRegisteredAndSubscriptionYearsFrom0UpTo6Years_Then_decimalExpectedResult(decimal amount, int customerType, int yearsOfSubscriptions, decimal expectedResult)
        {
            //Arrange
            var result = _discountManager.CalculateDiscountedAmount(amount, customerType, yearsOfSubscriptions);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
        #endregion

        #region MultiData Test for ValuableCustomerDiscountCalculator Amount:10m YearsOfSubscriptions From: 0 to 6 years
        private static IEnumerable<TestCaseData> AddCasesForValuableCustomer()
        {
            yield return new TestCaseData(10.0m, 3, 0, 7m);
            yield return new TestCaseData(10.0m, 3, 1, 6.93m);
            yield return new TestCaseData(10.0m, 3, 2, 6.86m);
            yield return new TestCaseData(10.0m, 3, 3, 6.79m);
            yield return new TestCaseData(10.0m, 3, 4, 6.72m);
            yield return new TestCaseData(10.0m, 3, 5, 6.65m);
            yield return new TestCaseData(10.0m, 3, 6, 6.65m);
        }


        [Test, TestCaseSource("AddCasesForValuableCustomer")]
        public void CalculateDiscountedAmount_When_AmountIs10andCustomerTypeIsValuableAndSubscriptionYearsFrom0UpTo6Years_Then_decimalExpectedResult(decimal amount, int customerType, int yearsOfSubscriptions, decimal expectedResult)
        {
            //Arrange
            var result = _discountManager.CalculateDiscountedAmount(amount, customerType, yearsOfSubscriptions);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
        #endregion

        #region MultiData Test for MostValuableCustomerDiscountCalculator Amount:10m YearsOfSubscriptions From: 0 to 6 years
        private static IEnumerable<TestCaseData> AddCasesForMostValuableCustomer()
        {
            yield return new TestCaseData(10.0m, 4, 0, 5m);
            yield return new TestCaseData(10.0m, 4, 1, 4.95m);
            yield return new TestCaseData(10.0m, 4, 2, 4.9m);
            yield return new TestCaseData(10.0m, 4, 3, 4.85m);
            yield return new TestCaseData(10.0m, 4, 4, 4.8m);
            yield return new TestCaseData(10.0m, 4, 5, 4.75m);
            yield return new TestCaseData(10.0m, 4, 6, 4.75m);
        }


        [Test, TestCaseSource("AddCasesForMostValuableCustomer")]
        public void CalculateDiscountedAmount_When_AmountIs10andCustomerTypeIsMostValuableAndSubscriptionYearsFrom0UpTo6Years_Then_decimalExpectedResult(decimal amount, int customerType, int yearsOfSubscriptions, decimal expectedResult)
        {
            //Arrange
            var result = _discountManager.CalculateDiscountedAmount(amount, customerType, yearsOfSubscriptions);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
        #endregion

        #region Test for NotImplementedCustomerDiscountCalculator
        private static IEnumerable<TestCaseData> AddCasesForNotImplementedCustomer()
        {
            yield return new TestCaseData(10.0m, 99, 10, "CustomerDiscountCalculator type not implemented!");
        }

        [Test, TestCaseSource("AddCasesForNotImplementedCustomer")]
        public void CalculateDiscountedAmount_When_CustomerIsNotImplemented_Then_NotImplementedException(decimal amount, int customerType, int yearsOfSubscriptions, string expectedException)
        {
            //Assert
            var ex = Assert.Catch<NotImplementedException>(() => _discountManager.CalculateDiscountedAmount(amount, customerType, yearsOfSubscriptions));
            Assert.That(ex.Message, Is.EqualTo(expectedException));
        }
        #endregion

        #region Test for NegativeYearsSubscriptions
        private static IEnumerable<TestCaseData> AddCasesNegativeYearsOfSubscription()
        {
            yield return new TestCaseData(10.0m, 2, -10, "Subscription years can't be less then 0.");
        }

        [Test, TestCaseSource("AddCasesNegativeYearsOfSubscription")]
        public void CalculateDiscountedAmount_When_YearsOfSubscriptionsIsLessThen0_Then_ArgumentException(decimal amount, int customerType, int yearsOfSubscriptions, string expectedException)
        {
            //Assert
            var ex = Assert.Catch<ArgumentException>(() => _discountManager.CalculateDiscountedAmount(amount, customerType, yearsOfSubscriptions));
            Assert.That(ex.Message, Is.EqualTo(expectedException));
        }
        #endregion

        #region Test for NegativeAmount
        private static IEnumerable<TestCaseData> AddCasesNegativeAmount()
        {
            yield return new TestCaseData(-10.0m, 2, 10, "Amount can't be less then 0.");
        }

        [Test, TestCaseSource("AddCasesNegativeAmount")]
        public void CalculateDiscountedAmount_When_AmountIsLessThen0_Then_ArgumentException(decimal amount, int customerType, int yearsOfSubscriptions, string expectedException)
        {
            //Assert
            var ex = Assert.Catch<ArgumentException>(() => _discountManager.CalculateDiscountedAmount(amount, customerType, yearsOfSubscriptions));
            Assert.That(ex.Message, Is.EqualTo(expectedException));
        }
        #endregion
    }





}