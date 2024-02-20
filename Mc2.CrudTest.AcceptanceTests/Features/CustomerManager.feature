Feature: Customer Manager

As a an operator I wish to be able to Create, Update, Delete customers and list all customers



@CreateBadEmail
Scenario: Operator attempts to create customer with bad email and gets bad request error
	Given first name Mohammad
	Given last name Bashirinia
	Given date of birth 1992-11-09
	Given phone number 09375226105
	Given email badEmail
	Given bank account number 223332
	When the customer is being created
	Then status code will be 400

@CreateBadPhoneNumber
Scenario: Operator attempts to create customer with bad IR phone number and gets bad request error
	Given first name Mohammad
	Given last name Bashirinia
	Given date of birth 1992-11-09
	Given phone number 044875226105
	Given email abc@yahoo.com
	Given bank account number 223332
	When the customer is being created
	Then status code will be 400

@CreateDuplicateFirstName
Scenario: Operator attempts to create customer with duplicate first name and gets bad request error
	Given There is another user with first name Mohammad
	Given first name Mohammad
	Given last name Bashirinia
	Given date of birth 1992-11-09
	Given phone number 09375226105
	Given email abc@yahoo.com
	Given bank account number 223332
	When the customer is being created
	Then status code will be 400

@CreateDuplicateLastName
Scenario: Operator attempts to create customer with duplicate last name and gets bad request error
	Given There is another user with last name Bashirinia
	Given first name Mohammad
	Given last name Bashirinia
	Given date of birth 1992-11-09
	Given phone number 09375226105
	Given email abc@yahoo.com
	Given bank account number 223332
	When the customer is being created
	Then status code will be 400

@CreateDuplicateDateOfBirth
Scenario: Operator attempts to create customer with duplicate date of birth and gets bad request error
	Given There is another user with date of birth 1992-11-09
	Given first name Mohammad
	Given last name Bashirinia
	Given date of birth 1992-11-09
	Given phone number 09375226105
	Given email abc@yahoo.com
	Given bank account number 223332
	When the customer is being created
	Then status code will be 400

@CreateDuplicateEmail
Scenario: Operator attempts to create customer with duplicate Email and gets bad request error
	Given There is another user with email abc@yahoo.com
	Given first name Mohammad
	Given last name Bashirinia
	Given date of birth 1992-11-09
	Given phone number 09375226105
	Given email abc@yahoo.com
	Given bank account number 223332
	When the customer is being created
	Then status code will be 400

@CreateGoodData
Scenario: Operator attempts to create customer with good data
	Given first name Mohammad
	Given last name Bashirinia
	Given date of birth 1992-11-09
	Given phone number 09375226105
	Given email abcd@yahoo.com
	Given bank account number 223332
	When the customer is being created
	Then status code will be 201