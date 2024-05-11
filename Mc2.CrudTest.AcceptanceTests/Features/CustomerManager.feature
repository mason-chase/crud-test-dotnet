Feature: Customer Manager

As a an operator I wish to be able to Create, Update, Delete customers and list all customers
	
@mytag
Scenario: Operator creates
	Given I am an operator
	When I create a Customer with following details 
		| FirstName | LastName | DateOfBirth | PhoneNumber | Email | BankAccountNumber
  		| Mohammad | Dehghani | 01/02/1989 | +989010596159 | "dehghany.m@gmail.com" | 123456 
	Then The customer should be created successfully


