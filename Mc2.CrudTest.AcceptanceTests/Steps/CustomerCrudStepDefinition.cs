using CrudTest.Data.Context;
using CrudTest.Models.Entities.Marketing.Customers;
using CrudTest.Services.Common;
using CrudTest.Services.Features.Marketing.Customers.DeleteCustomer;
using CrudTest.Services.Features.Marketing.Customers.DTOs;
using FluentAssertions;
using Mc2.CrudTest.AcceptanceTests.API;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.AcceptanceTests.Steps
{
    [Binding]
    public class CustomerCrudStepDefinition
    {
        private readonly CustomerApi _customerApi;

        private int _statusCode;

        private Response<dynamic>? _response;
        private List<CustomerResponseDto>? _customers;

        private readonly MarketingDbContext _context;

        private Guid? _existingId;
        public CustomerCrudStepDefinition(CustomerApi customerApi)
        {
            _customerApi = customerApi;
            _context =  customerApi.Factory.Server.Services.GetService<MarketingDbContext>()!;
            
        }

        [Given("There is another user with first name (.*)")]
        public async Task GivenThereIsAnotherUserWithFirstName(string firstName)
        {
            var customer = Customer.Create(firstName, Guid.NewGuid().ToString()
                , DateOnly.Parse("1995-10-11"), 12141, $"{Guid.NewGuid()}@yahoo.com", 12314);


            _context.Customers.Add(customer);

            await _context.SaveChangesAsync();
        }

        [Given("There is another user with last name (.*)")]
        public async Task GivenThereIsAnotherUserWithLastName(string lastName)
        {
            var customer = Customer.Create(Guid.NewGuid().ToString(), lastName
                , DateOnly.Parse("1995-10-11"), 12141, $"{Guid.NewGuid()}@yahoo.com", 12314);


            _context.Customers.Add(customer);

            await _context.SaveChangesAsync();
        }

        [Given("There is another user with date of birth (.*)")]
        public async Task GivenThereIsAnotherUserWithDateOfBirth(DateOnly dateofBirth)
        {
            var customer = Customer.Create(Guid.NewGuid().ToString(), Guid.NewGuid().ToString()
                , dateofBirth, 12141, $"{Guid.NewGuid()}@yahoo.com", 12314);


            _context.Customers.Add(customer);

            await _context.SaveChangesAsync();
        }

        [Given("There is another user with email (.*)")]
        public async Task GivenThereIsAnotherUserWithEmail(string email)
        {
            var customer = Customer.Create(Guid.NewGuid().ToString(), Guid.NewGuid().ToString()
                , DateOnly.Parse("1995-10-11"), 12141, email, 12314);


            _context.Customers.Add(customer);

            await _context.SaveChangesAsync();
        }

        [Given("There is another user with Id")]
        public async Task GivenThereIsAnotherUserWithId()
        {
            var customer = Customer.Create(Guid.NewGuid().ToString(), Guid.NewGuid().ToString()
                , DateOnly.Parse("1995-10-11"), 12141, "abc@yahoo.com", 12314);


            _context.Customers.Add(customer);

            await _context.SaveChangesAsync();
            _existingId = customer.Id;
        }

        [Given("first name (.*)")]

        public void GivenFirstName(string firstName)
        {
            _customerApi.CreateCustomerCommand.FirstName = firstName;
        }

        [Given("last name (.*)")]

        public void GivenLastName(string lastName)
        {
            _customerApi.CreateCustomerCommand.LastName = lastName;
        }

        [Given("date of birth (.*)")]

        public void GivenDateOfBirth(DateOnly dateofBirth)
        {
            _customerApi.CreateCustomerCommand.DateOfBirth = dateofBirth;
        }

        [Given("phone number (.*)")]

        public void GivenPhoneNumber(ulong phoneNumber)
        {
            _customerApi.CreateCustomerCommand.PhoneNumber = phoneNumber;
        }

        [Given("email (.*)")]

        public void GivenEmail(string email)
        {
            _customerApi.CreateCustomerCommand.Email = email;
        }

        [Given("bank account number (.*)")]

        public void GivenBankAccountNumber(ulong bankAccountNumber)
        {
            _customerApi.CreateCustomerCommand.BankAccountNumber = bankAccountNumber;
        }


        [When("the customer is being created")]

        public async Task WhenCustomerIsBeingCreated()
        {
            var result = await _customerApi.CreateAsync();

            _statusCode = (int)result.StatusCode;
        }

        [When("we want to see all customers")]

        public async Task WhenWeWantToSeeAllCustomers()
        {
            _customers = await _customerApi.GetAllAsync();

        }

        [When("we want to delete customer with id (.*)")]

        public async Task WeWantToDeleteCustomerWithId(string id)
        {
            Guid deleteId;

            if(id == "existing")
            {
                deleteId = _existingId!.Value;
            }

            else
            {
                deleteId = Guid.Parse(id);
            }

            var result = await _customerApi.DeleteAsync(deleteId);

            _statusCode = result.StatusCode;
            _response = result;

        }

        [Then("the response has success true")]
        public void ResponseHasSuccessTrue()
        {
            _response!.Success.Should().BeTrue();
        }
        [Then("customer list will be empty")]
        public void CustomerListWillBeEmpty()
        {
            _customers.Should().BeEmpty();
        }

        [Then("customer list will have (.*) customers")]
        public void CustomerListWillBeEmpty(int count)
        {
            _customers.Should().HaveCount(count);
        }

        [Then("status code will be (.*)")]

        public void ThenTheStatusCodeWillBe(int statusCode)
        {
            _statusCode.Should().Be(statusCode);
        }

        [Then("there will not be a customer with existing id")]
        public async void ThereWillNotBeCustomerWithExistingId()
        {
            var result = await _context.Customers.AnyAsync(x => x.Id == _existingId);

            result.Should().BeFalse();
        }
    }
}
