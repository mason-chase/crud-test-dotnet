Feature: Customer Manager

As a an operator I wish to be able to Create, Update, Delete customers and list all customers
	
Scenario: Create, Read, Edit, and Delete Customer
	Given platform has 0 customers
	When user creates a customer with the following data by sending Create Customer Command through API
		| FirstName | LastName | Email                 | PhoneNumber  | Country | DateOfBirth | BankAccountNumber          |
		| mohammad  | Mobasher | mohammad@Mobasher.com | +09191600836 | IR      | 2000-JAN-15 | IR330620000000202901868005 |
	Then user can query to get all customers and must have 1 record with the below data
		| FirstName | LastName | Email                 | PhoneNumber  | Country | DateOfBirth | BankAccountNumber          |
		| mohammad  | Mobasher | mohammad@Mobasher.com | +09191600836 | IR      | 2000-JAN-15 | IR330620000000202901868005 |
	When user creates a customer with the same data by sending Create Customer Command through API
		| FirstName | LastName | Email                 | PhoneNumber  | Country | DateOfBirth | BankAccountNumber          |
		| mohammad  | Mobasher | mohammad@Mobasher.com | +09191600836 | IR      | 2000-JAN-15 | IR330620000000202901868005 |
	Then user must get error codes
		| Codes |
		| 400   |

	When user creates a customer with an invalid mobile number, email, and bank account number
		| FirstName | LastName | Email            | PhoneNumber | DateOfBirth | BankAccountNumber |
		| Ali       | Hasani   | invalidEmail.com | +989121237  | 2000-JAN-13 | IR33062000000     |
	Then user must get error codes
		| Codes |
		| 400   |

	When user edits customer with new data
		| Id | FirstName | LastName | Email             | PhoneNumber  | Country | DateOfBirth | BankAccountNumber          |
		| 1  | Hasan     | Delavar  | Hasan@delavar.com | +09121600836 | IR      | 2000-FEB-01 | IR330620000000202901868006 |

	When user deletes customer by Id 1
	Then user can query to get all customers and get 0 records
