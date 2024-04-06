Feature: Customer Manager

As a an operator I wish to be able to Create, Update, Delete customers and list all customers

Scenario: Create a new customer with valid data
	Given the following customer details
		| FirstName | LastName | DateOfBirth | PhoneNumber | Email                | BankAccountNumber |
		| John      | Doe      | 1985-10-15  | +1234567890 | john.doe@example.com | 1234567890123456  |
	When I send a request to create a new customer
	Then the customer should be created successfully

Scenario: Create a new customer with invalid data
	Given the following customer details
		| FirstName | LastName | DateOfBirth | PhoneNumber    | Email                | BankAccountNumber |
		| John      | Doe      | 1985-10-15  | invalid_number | john.doe@example.com | 1234567890123456  |
	When I send a request to create a new customer
	Then the request should fail with a validation error for PhoneNumber

	Given the following customer details
		| FirstName | LastName | DateOfBirth | PhoneNumber | Email                     | BankAccountNumber |
		| John      | Doe      | 1985-10-15  | +1234567890 | invalid_email@example.com | 1234567890123456  |
	When I send a request to create a new customer
	Then the request should fail with a validation error for Email

	Given the following customer details
		| FirstName | LastName | DateOfBirth | PhoneNumber | Email                | BankAccountNumber |
		| John      | Doe      | 1985-10-15  | +1234567890 | john.doe@example.com | invalid_number    |
	When I send a request to create a new customer
	Then the request should fail with a validation error for BankAccountNumber

Scenario: Update an existing customer with valid data
	Given there is an existing customer with the following details
		| Id | FirstName | LastName | DateOfBirth | PhoneNumber | Email                | BankAccountNumber |
		| 1  | John      | Doe      | 1985-10-15  | +1234567890 | john.doe@example.com | 1234567890123456  |
	And the following updated customer details
		| Id | FirstName | LastName | DateOfBirth | PhoneNumber | Email                | BankAccountNumber |
		| 1  | Jane      | Doe      | 1985-10-15  | +1234567890 | jane.doe@example.com | 1234567890123456  |
	When I send a request to update the customer
	Then the customer should be updated successfully

Scenario: Update an existing customer with invalid data
	Given there is an existing customer with the following details
		| Id | FirstName | LastName | DateOfBirth | PhoneNumber | Email                | BankAccountNumber |
		| 1  | John      | Doe      | 1985-10-15  | +1234567890 | john.doe@example.com | 1234567890123456  |
	And the following updated customer details
		| Id | FirstName | LastName | DateOfBirth | PhoneNumber    | Email                | BankAccountNumber |
		| 1  | John      | Doe      | 1985-10-15  | invalid_number | john.doe@example.com | 1234567890123456  |
	When I send a request to update the customer
	Then the request should fail with a validation error for PhoneNumber

	Given there is an existing customer with the following details
		| Id | FirstName | LastName | DateOfBirth | PhoneNumber | Email                | BankAccountNumber |
		| 1  | John      | Doe      | 1985-10-15  | +1234567890 | john.doe@example.com | 1234567890123456  |
	And the following updated customer details
		| Id | FirstName | LastName | DateOfBirth | PhoneNumber | Email                     | BankAccountNumber |
		| 1  | John      | Doe      | 1985-10-15  | +1234567890 | invalid_email@example.com | 1234567890123456  |
	When I send a request to update the customer
	Then the request should fail with a validation error for Email

	Given there is an existing customer with the following details
		| Id | FirstName | LastName | DateOfBirth | PhoneNumber | Email                | BankAccountNumber |
		| 1  | John      | Doe      | 1985-10-15  | +1234567890 | john.doe@example.com | invalid_number    |
	And the following updated customer details
		| Id | FirstName | LastName | DateOfBirth | PhoneNumber | Email                | BankAccountNumber |
		| 1  | John      | Doe      | 1985-10-15  | +1234567890 | john.doe@example.com | invalid_number    |
	When I send a request to update the customer
	Then the request should fail with a validation error for BankAccountNumber

Scenario: Get an existing customer by ID
	Given there is an existing customer with the following details
		| Id | FirstName | LastName | DateOfBirth | PhoneNumber | Email                | BankAccountNumber |
		| 1  | John      | Doe      | 1985-10-15  | +1234567890 | john.doe@example.com | 1234567890123456  |
	When I send a request to get the customer by ID
	Then the customer details should be returned successfully

Scenario: Get all customers
	Given there are existing customers in the database
	When I send a request to get all customers
	Then the list of customers should be returned successfully

Scenario: Delete an existing customer by ID
	Given there is an existing customer with the following details
		| Id | FirstName | LastName | DateOfBirth | PhoneNumber | Email                | BankAccountNumber |
		| 1  | John      | Doe      | 1985-10-15  | +1234567890 | john.doe@example.com | 1234567890123456  |
	When I send a request to delete the customer by ID
	Then the customer should be deleted successfully
