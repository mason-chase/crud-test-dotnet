@automated
@CustomerManagement
Feature: Customer Manager
As a an operator I wish to be able to Create, Update, Delete customers and list all customers

    Scenario: Create a new Customer
        Given There is no Customer with following data
          | Firstname | Lastname | DateOfBirth | PhoneNumber     | Email             | BankAccountNumber |
          | John      | Doe      | 2024-01-05  | +1 419-437-3751 | JohnDoe@gmail.com | 12345678          |
        When Create new Customer api is called with the given data
        Then Customer should Be created with the given data
        