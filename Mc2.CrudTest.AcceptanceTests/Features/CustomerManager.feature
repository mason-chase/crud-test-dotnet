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


@GetAllNoData
Scenario: Operator gets all the data but there are none so empty list is returned
	When we want to see all customers
	Then customer list will be empty
	
@GetAllOneData
Scenario: Operator gets all the data and there is 1 data so a list of 1 is returned
	Given There is another user with email abc@yahoo.com
	When we want to see all customers
	Then customer list will have 1 customers

@GetAllThreeData
Scenario: Operator gets all the data and there is 3 data so a list of 3 is returned
	Given There is another user with email abc1@yahoo.com
	Given There is another user with email abc2@yahoo.com
	Given There is another user with email abc3@yahoo.com
	When we want to see all customers
	Then customer list will have 3 customers


@DeleteCustomerBadId
Scenario: Operator attempts to delete a customer that does not exists and gets 404 error
	When we want to delete customer with id a286eced-b158-4f81-b51d-c412f1298b8d
	Then status code will be 404

@DeleteCustomerGoodId
Scenario: Operator attempts to delete a customer that exists and gets success
	Given There is another user with Id
	When we want to delete customer with id existing
	Then the response has success true
	Then there will not be a customer with existing id