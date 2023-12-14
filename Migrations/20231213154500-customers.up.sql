create schema customers;
--;;
CREATE TABLE customers.customers (

     Id int unique not null,
     Firstname varchar,
     Lastname varchar,
     DateOfBirth timestamp(1) without time zone,
     PhoneNumber varchar(15),
     Email varchar,
     BankAccountNumber varchar(20)
);
--;;