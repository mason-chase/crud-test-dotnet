Feature: Create Customer

As an operator, I wish to be able to Create New Customer

Scenario: Creating a new customer with an invalid mobile number

    Given the user is entering a new customer with an invalid mobile number "123-456-7890"
    When the user tries to add the customer with the invalid mobile number
    Then the system should display an error message indicating an invalid mobile number
    

Scenario: Creating a new customer with a valid mobile number
    Given the user is entering a new customer with a valid mobile number "+123456789012"
    When the user adds the customer with the valid mobile number
    Then the system should successfully add the new customer to the database
    And the user should receive a confirmation message

Scenario: Creating a new customer with an invalid email address
    Given the user is entering a new customer with an invalid email address "john.doe@example"
    When the user tries to add the customer with the invalid email address
    Then the system should display an error message indicating an invalid email address
    

Scenario: Creating a new customer with a valid email address
    Given the user is entering a new customer with a valid email address "jane.smith@example.com"
    When the user adds the customer with the valid email address
    Then the system should successfully add the new customer to the database
    And the user should receive a confirmation message

Scenario: Creating a new customer with a duplicate email
    Given the system has an existing customer with the email address "john.doe@example.com"
    When the user adds a new customer with the same email address "john.doe@example.com"
    Then the system should display an error message indicating a duplicate email


Scenario: Creating a new customer with a unique email
    Given the system has no existing customer with the email address "jane.smith@example.com"
    When the user adds a new customer with the email address "jane.smith@example.com"
    Then the system should successfully add the new customer to the database
    And the user should receive a confirmation message

Scenario: Creating a new customer with an invalid bank account number
    Given the user is entering a new customer with an invalid bank account number "ABC123456789"
    When the user tries to add the customer with the invalid bank account number
    Then the system should display an error message indicating an invalid bank account number

Scenario: Creating a new customer with a valid bank account number
    Given the user is entering a new customer with a valid bank account number "12345678901234"
    When the user adds the customer with the valid bank account number
    Then the system should successfully add the new customer to the database
    And the user should receive a confirmation message
	
Scenario: Successful Create Customer
	When the user create a customer with a valid data 
	Then the user should see create customer successful message

Scenario: Creating a new customer with duplicate details
    Given the system has no existing customer with the following details:
      | Firstname  | Lastname   | DateOfBirth  |
      | John       | Doe        | 1990-01-01   |
    When the user adds a new customer with the same details:
      | Firstname  | Lastname   | DateOfBirth  |
      | John       | Doe        | 1990-01-01   |
    Then the system should display an error message indicating duplicate customer details
    And the customer should not be added to the database

Scenario: Creating a new customer with unique details
    Given the system has no existing customer with the following details:
      | Firstname  | Lastname   | DateOfBirth  |
      | John       | Doe        | 1990-01-01   |
    When the user adds a new customer with different details:
      | Firstname  | Lastname   | DateOfBirth  |
      | Jane       | Smith      | 1985-05-10   |
    Then the system should successfully add the new customer to the database
    And the user should receive a confirmation message