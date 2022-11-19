using DiscountManagerApp;
using DiscountManagerApp.Entities;
using DiscountManagerApp.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace NTestDiscountManagerApp
{

    public class DiscountManagerTestFactory
    {
        ICustomerDiscountCalculatorFactory _customerDiscountCalculatorFactory;
        DiscountManager _discountManager;


        [SetUp]
        public void Setup()
        {
            Dictionary<ECustomerType, ICustomerDiscountCalculatorV2> dictCustomerDiscountCalculator = new Dictionary<ECustomerType, ICustomerDiscountCalculatorV2>();
            dictCustomerDiscountCalculator.Add(ECustomerType.NOT_REGISTERED, new NotRegisteredCustomerDiscountCalculator());
            dictCustomerDiscountCalculator.Add(ECustomerType.REGISTERED, new RegisteredCustomerDiscountCalculator());
            dictCustomerDiscountCalculator.Add(ECustomerType.VALUABLE, new ValuableCustomerDiscountCalculator());
            dictCustomerDiscountCalculator.Add(ECustomerType.MOST_VALUABLE, new MostValuableCustomerDiscountCalculator());
            _customerDiscountCalculatorFactory =new CustomerDiscountCalculatorFactory(dictCustomerDiscountCalculator);
            _discountManager = new DiscountManager(_customerDiscountCalculatorFactory);
        }

        [Test]
        public void GetCustomerDiscountCalculatorConcreteType_When_CustomerTypeIsNotRegistered_Then_ReturnIsIstanceOfNotRegisteredCustomerDiscountCalculator() 
        {
            //Arrange
            ECustomerType customerType = ECustomerType.NOT_REGISTERED;

            //Act
            var customerDiscountCalculatorResult=_customerDiscountCalculatorFactory.GetCustomerDiscountCalculatorConcreteType(customerType);

            //Assert
            Assert.IsInstanceOf(typeof(NotRegisteredCustomerDiscountCalculator), customerDiscountCalculatorResult);
        }

        [Test]
        public void GetCustomerDiscountCalculatorConcreteType_When_CustomerTypeIsRegistered_Then_ReturnIsIstanceOfRegisteredCustomerDiscountCalculator()
        {
            //Arrange
            ECustomerType customerType = ECustomerType.REGISTERED;

            //Act
            var customerDiscountCalculatorResult = _customerDiscountCalculatorFactory.GetCustomerDiscountCalculatorConcreteType(customerType);

            //Assert
            Assert.IsInstanceOf(typeof(RegisteredCustomerDiscountCalculator), customerDiscountCalculatorResult);
        }

        [Test]
        public void GetCustomerDiscountCalculatorConcreteType_When_CustomerTypeIsValuable_Then_ReturnIsIstanceOfValuableCustomerDiscountCalculator()
        {
            //Arrange
            ECustomerType customerType = ECustomerType.VALUABLE;

            //Act
            var customerDiscountCalculatorResult = _customerDiscountCalculatorFactory.GetCustomerDiscountCalculatorConcreteType(customerType);

            //Assert
            Assert.IsInstanceOf(typeof(ValuableCustomerDiscountCalculator), customerDiscountCalculatorResult);
        }

        [Test]
        public void GetCustomerDiscountCalculatorConcreteType_When_CustomerTypeIsMostValuable_Then_ReturnIsIstanceOfMostValuableCustomerDiscountCalculator()
        {
            //Arrange
            ECustomerType customerType = ECustomerType.MOST_VALUABLE;

            //Act
            var customerDiscountCalculatorResult = _customerDiscountCalculatorFactory.GetCustomerDiscountCalculatorConcreteType(customerType);

            //Assert
            Assert.IsInstanceOf(typeof(MostValuableCustomerDiscountCalculator), customerDiscountCalculatorResult);
        }

        [Test]
        public void CalculateDiscountedAmount_When_CustomerIsNotImplemented_Then_NotImplementedException()
        {
            //Arrange
            decimal amount = 10;
            int customerType = 99;
            int subscriptionsYears = 6;
            string expectedException = "CustomerDiscountCalculator type not implemented!";

            //Assert
            var ex = Assert.Catch<NotImplementedException>(() => _discountManager.CalculateDiscountedAmount(amount, customerType, subscriptionsYears));
            Assert.That(ex.Message, Is.EqualTo(expectedException));
        }
    }
}