Feature: Customer Management

As a an operator I wish to be able to Create, Update, Delete customers and list all customers
	
Scenario: Add A New Customer
	Given a customer with the following details:
		| FirstName | LastName | DateOfBirth | PhoneNumber | Email                | BankAccountNumber |
		| John      | Doe      | 1985-05-13  | 09120432460 | john.doe@example.com | 1234567890        |
	When the user adds the customer
	Then the customer should be successfully added