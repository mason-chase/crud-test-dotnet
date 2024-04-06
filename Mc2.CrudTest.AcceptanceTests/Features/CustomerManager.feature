Feature: Customer Manager

As a an operator I wish to be able to Create, Update, Delete customers and list all customers
@create
Scenario: Create a new customer with valid data
	When I create customers with the following details
		| FirstName | LastName | DateOfBirth              | PhoneNumber       | Email                | BankAccountNumber |
		| Jack      | Doe      | 1985-10-15T18:30:00.000Z | +1 (650) 253-0000 | john.doe@example.com | 100200300400      |
	Then the customer should be created successfully
@create
Scenario: Create a new customer with duplicate Email
	When I create customers with the following details
		| FirstName | LastName | DateOfBirth              | PhoneNumber       | Email                | BankAccountNumber |
		| Jeoffrey  | Doe      | 1985-10-15T18:30:00.000Z | +1 (650) 253-0000 | Jeoffrey.doe@example.com | 100200300400      |
	When I create customers with the following details with duplicate email
		| FirstName | LastName | DateOfBirth              | PhoneNumber       | Email                | BankAccountNumber |
		| Jon       | Doe      | 1985-10-15T18:30:00.000Z | +1 (650) 253-0000 | Jeoffrey.doe@example.com | 100200300400      |
	Then the second request with duplicate Email should fail with a validation error
@create
Scenario: Create a new customer with duplicate details
	When I create customers with the following details
		| FirstName | LastName | DateOfBirth              | PhoneNumber       | Email                | BankAccountNumber |
		| Jesus     | Doe      | 1985-10-15T18:30:00.000Z | +1 (650) 253-0000 | Jesus.doe@example.com | 100200300400      |
	When I create customers with the following details with duplicate detail
		| FirstName | LastName | DateOfBirth              | PhoneNumber       | Email                 | BankAccountNumber |
		| Jesus     | Doe      | 1985-10-15T18:30:00.000Z | +1 (650) 253-0000 | different@example.com | 100200300400      |
	Then the second request with duplicate detail should fail with a validation error
@create
Scenario: Create a new customer with invalid data
	When I send a request with invalid PhoneNumber to create a new customer
		| FirstName | LastName | DateOfBirth | PhoneNumber    | Email                 | BankAccountNumber |
		| Joe       | Doe      | 1985-10-15  | invalid_number | john.doe1@example.com | 100200300400      |
	Then the request should fail with a validation error for PhoneNumber

	When I send a request with invalid Email to create a new customer
		| FirstName | LastName | DateOfBirth | PhoneNumber | Email                     | BankAccountNumber |
		| Jake      | Doe      | 1985-10-15  | +1234567890 | invalid_email@example.com | 100200300400      |
	Then the request should fail with a validation error for Email

	When I send a request with invalid BankAccountNumber to create a new customer
		| FirstName | LastName | DateOfBirth | PhoneNumber | Email                 | BankAccountNumber |
		| Jin       | Doe      | 1985-10-15  | +1234567890 | john.doe2@example.com | invalid_number    |
	Then the request should fail with a validation error for BankAccountNumber
@update
Scenario: Update an existing customer with valid data
	Given there is an existing customer with the following details
		| FirstName | LastName | DateOfBirth | PhoneNumber       | Email                 | BankAccountNumber |
		| Jerard    | Doe      | 1985-10-15  | +1 (650) 253-0000 | john.doe3@example.com | 100200300400      |
	When I send a request to update the customer with following detail
		| Id | FirstName | LastName | DateOfBirth | PhoneNumber       | Email                 | BankAccountNumber |
		| 1  | Janet     | Doe      | 1985-10-15  | +1 (650) 253-0000 | janet.doe@example.com | 100200300400      |
	Then the customer should be updated successfully
@update
Scenario: Update an existing customer with invalid data
	Given there is an existing customer with the following details
		| FirstName | LastName | DateOfBirth | PhoneNumber       | Email                 | BankAccountNumber |
		| Joey      | Doe      | 1985-10-15  | +1 (650) 253-0000 | john.doe4@example.com | 100200300400      |
	When I send a request to update the customer with invalid PhoneNumber with the following details
		| Id | FirstName | LastName | DateOfBirth | PhoneNumber    | Email                 | BankAccountNumber |
		| 1  | Jane      | Doe      | 1985-10-15  | invalid_number | john.doe4@example.com | 100200300400      |
	Then the request should fail with a validation error for PhoneNumber

	When I send a request to update the customer with invalid Email with the following details
		| Id | FirstName | LastName | DateOfBirth | PhoneNumber       | Email         | BankAccountNumber |
		| 1  | Jane      | Doe      | 1985-10-15  | +1 (650) 253-0000 | invalid_email | 100200300400      |
	Then the request should fail with a validation error for Email

	When I send a request to update the customer with invalid BankAccountNumber with the following details
		| Id | FirstName | LastName | DateOfBirth | PhoneNumber       | Email                 | BankAccountNumber |
		| 1  | Jane      | Doe      | 1985-10-15  | +1 (650) 253-0000 | john.doe5@example.com | invalid_number    |
	Then the request should fail with a validation error for BankAccountNumber
@read
Scenario: Get an existing customer by ID
	Given there is an existing customer with the following details
		| FirstName | LastName | DateOfBirth | PhoneNumber       | Email                 | BankAccountNumber |
		| Johnathan | Doe      | 1985-10-15  | +1 (650) 253-0000 | john.doe6@example.com | 100200300400      |
	When I send a request to get the customer by ID
	Then the customer details should be returned successfully
@read
Scenario: Get all customers
	Given there is an existing customer with the following details
		| FirstName | LastName | DateOfBirth | PhoneNumber       | Email                 | BankAccountNumber |
		| John      | Doe      | 1985-10-15  | +1 (650) 253-0000 | john.doe7@example.com | 100200300400      |
	When I send a request to get all customers
	Then the list of customers should be returned successfully
@delete
Scenario: Delete an existing customer by ID
	Given there is an existing customer with the following details
		| FirstName | LastName | DateOfBirth | PhoneNumber       | Email                 | BankAccountNumber |
		| Jackey    | Doe      | 1985-10-15  | +1 (650) 253-0000 | john.doe8@example.com | 100200300400      |
	When I send a request to delete the customer by ID
	Then the customer should be deleted successfully
