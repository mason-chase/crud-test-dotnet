Feature: Create Customer

As an operator, I wish to be able to Create New Customer

Scenario: Mobile Number Validation
	When the user creates a customer with an invalid Mobile Number
	Then the user should see a Mobile Number validation error

Scenario: Email Validation 
	When the user creates a customer with an invalid Email
	Then the user should see an Email validation error

Scenario: Email should be unique 
	Given there is a customer with Email 'info@company.com' in the database
	When the user creates a customer with Email 'info@company.com'
	Then the user should see an Email duplication error

Scenario: Bank Account Number Validation 
	When the user creates a customer with an invalid Bank Account Number
	Then the user should see a Bank Account Number validation error
	
Scenario: Successful Create Customer
	When the user create a customer with a valid data 
	Then the user should see create customer successful message