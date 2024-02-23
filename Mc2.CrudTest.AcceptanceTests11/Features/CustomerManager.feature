Feature: Customer Manager

As a an operator I wish to be able to Create, Update, Delete customers and list all customers
	
@mytag
Scenario: Add a new customer
	Given a customer with the following details:
		| FirstName | LastName | DateOfBirth | PhoneNumber | Email                | BankAccountNumber | IsDeleted |
		| John      | Doe      | 1985-05-15  | +1234567890 | john.doe@example.com | 1234567890        | false     |
	When the user adds the customer
	Then the customer should be successfully added