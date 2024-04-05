Feature: Customer Manager

As a an operator I wish to be able to Create, Update, Delete customers and list all customers
	
@create
Scenario: Create a new customer
	Given I have entered FirstName "<FirstName>"
	And I have entered LastName "<LastName>"
	And I have entered DateOfBirth "<DateOfBirth>"
	And I have entered PhoneNumber "<PhoneNumber>"
	And the combination of FirstName "<FirstName>", LastName "<LastName>" and DateOfBirth "<DateOfBirth>" is not duplicate
	And the PhoneNumber "<PhoneNumber>" is a valid mobile number
	And I have entered Email "<Email>"
	And the Email "<Email>" is valid
	And the Email "<Email>" is not duplicate
	And I have entered BankAccountNumber "<BankAccountNumber>"
	And the BankAccountNumber "<BankAccountNumber>" is valid
	When I create a new customer
	Then the customer should be saved successfully

@read
Scenario: Read customer information
	Given there is a customer with FirstName "<FirstName>", LastName "<LastName>"
	When I request customer information
	Then I should see the details of the customer including DateOfBirth, PhoneNumber, Email, and BankAccountNumber

@update
Scenario: Update customer information
	Given there is a customer with FirstName "<FirstName>", LastName "<LastName>"
	And I have entered new DateOfBirth "<NewDateOfBirth>"
	And I have entered new PhoneNumber "<NewPhoneNumber>"
	And the combination of FirstName "<FirstName>", LastName "<LastName>" and DateOfBirth "<DateOfBirth>" is not duplicate
	And the new PhoneNumber "<NewPhoneNumber>" is a valid mobile number
	And I have entered new Email "<NewEmail>"
	And the new Email "<NewEmail>" is valid
	And the Email "<Email>" is not duplicate
	And I have entered new BankAccountNumber "<NewBankAccountNumber>"
	And the new BankAccountNumber "<NewBankAccountNumber>" is valid
	When I update the customer information
	Then the customer information should be updated successfully

@delete
Scenario: Delete a customer
	Given there is a customer with Email "<Email>"
	When I delete the customer
	Then the customer should be removed from the system
