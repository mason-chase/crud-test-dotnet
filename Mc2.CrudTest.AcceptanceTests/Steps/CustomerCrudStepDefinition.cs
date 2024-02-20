using CrudTest.Data.Context;
using CrudTest.Models.Entities.Marketing.Customers;
using FluentAssertions;
using Mc2.CrudTest.AcceptanceTests.API;
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

        private readonly MarketingDbContext _context;
        public CustomerCrudStepDefinition(CustomerApi customerApi)
        {
            _customerApi = customerApi;
            _context =  customerApi.Factory.Server.Services.GetService<MarketingDbContext>()!;
            
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

        [Then("status code will be (.*)")]

        public void ThenTheStatusCodeWillBe(int statusCode)
        {
            _statusCode.Should().Be(statusCode);
        }
    }
}
