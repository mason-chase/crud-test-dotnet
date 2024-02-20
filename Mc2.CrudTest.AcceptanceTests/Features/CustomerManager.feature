Feature: Customer Manager

As a an operator I wish to be able to Create, Update, Delete customers and list all customers
	
@mytag
Scenario: Operator creates, list, update and delete customers 
	Given to be filled...
	When to be filled...
	Then to be filled...

@Create
Scenario: Operator attempts to create customer with bad data
	Given first name Mohammad
	Given last name Bashirinia
	Given date of birth 1992-11-09
	Given phone number 99
	Given email abc@yahoo.com
	Given bank account number 223332
	When the customer is being created
	Then status code will be 500