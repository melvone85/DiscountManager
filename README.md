# DiscountManagerApp

##Target

Refactoring of Legacy DiscountManagerCalculate class

## Project structure

- ### Presentation

- **Program.cs**
	Console Application it take care of:
		`Create the logic of the application`
		`Create the Factory class and inject it into logic.`
		`Create the Dictionary with the possible customers and inject it into factory`
		`Calculate the Total Amount with the Discount applied with the parameters given in input`
		`Print the Calculated result in the console`

- ### Logic

- **DiscountManager.cs**
	Main logic of DiscountManagerApp it takes care of:
		`Check for possible input data Exceptions.`
		`Take the right CustomerDiscountCalculator through the  factory class using the injected class.`
		`Return the right amount with the right Discount.`
		
- ### Entities

- **IBaseCustomerDiscountCalculator.cs**
		`Abstract class that implement ICustomerDiscountCalculatorV2 inherited from Concrete customers and is main job is to implement some common calculations such as CalculateLoyaltyDiscount and CalculateCustomAmountDiscount, and make abstract the method CalculateDiscountAmount to allow concrete customers to override it.`
- **ICustomerDiscountCalculatorFactory.cs**
		`Implement ICustomerDiscountCalculatorFactory and is main job is to give back a concrete customer type depending on the enum parameter given in input. Also throw exception if customer is not implemented.`

- **MostValuableCustomerDiscountCalculator.cs**
		`Implementation of MostValuableCustomer inherit and implement abstract class BaseCustomerDiscountCalculator and give back the amount discounted.`
		
- **INotRegisteredCustomerDiscountCalculator.cs**
		`Implementation of NotRegisteredCustomer inherit and implement abstract class BaseCustomerDiscountCalculator and give back the amount discounted.`

- **IRegisteredCustomerDiscountCalculator.cs**
		`Implementation of RegisteredCustomer inherit and implement abstract class BaseCustomerDiscountCalculator and give back the amount discounted.`

- **IValuableCustomerDiscountCalculator.cs**
		`Implementation of ValuableCustomer inherit and implement abstract class BaseCustomerDiscountCalculator and give back the amount discounted.`

	####Interfaces
	
- **ICustomerDiscountCalculator.cs**
		`Original interface from the legacy code implemented by the Logic DiscountManager class`
- **ICustomerDiscountCalculatorFactory.cs**
		`Interface implemented by the concrete Factory CustomerDiscountCalculatorFactory`
		
-  **ICustomerDiscountCalculatorV2.cs**
		`Interface implemented by the Abstract class BaseCustomerDiscountCalculator.`

	####NUnit test
- 	Project test are done using NUnit and they check for the correctness of the values returned by Concrete Customers and also check for Concrete Object returned by the factory. 