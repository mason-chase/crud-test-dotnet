using Mc2.CrudTest.AcceptanceTests.Drivers;
using Mc2.CrudTest.Presentation.Client.Models.Customers;
using System.Net;
using Xunit;
using Mc2.CrudTest.Presentation.Shared.Extensions;
using TechTalk.SpecFlow.Assist;
using System.Net.Http.Json;
using Azure;
using Domain.Entities;


namespace Mc2.CrudTest.AcceptanceTests.Steps
{
    [Binding]
    public class CustomerManagerStepDefinitions : BaseTest
    {
        private string CustomerEndPoint { get; set; }
        private HttpResponseMessage ErrorResponse { get; set; } = null!;

        public CustomerManagerStepDefinitions()
        {
            CustomerEndPoint = $"{ApiUri}api/customer";
        }


        [Given(@"platform has (.*) customers")]
        public void GivenPlatformHasCustomers(int customerNumber)
        {
            var response = Task.Run(async () => await Client.GetAsync(CustomerEndPoint + "/GetAll")).Result;
            Assert.True(response != null && response.StatusCode == HttpStatusCode.OK, "Get All Customer Integration Test Completed");
            var customers = response.ToResult<List<CustomerDTO>>().Result;
            Assert.Equal(customers.Data.Count, customerNumber);
        }

        [When(@"user creates a customer with the following data by sending Create Customer Command through API")]
        public void WhenUserCreatesACustomerWithTheFollowingDataBySendingCreateCustomerCommandThroughAPI(Table table)
        {
            var customer = table.CreateInstance<CreateCustomerDTO>();
            var response = Task.Run(async () => await Client.PostAsJsonAsync(CustomerEndPoint + "/Create", customer)).Result;
            var result = response.ToResult<int>().Result;
            Assert.True(result.Succeeded);
        }

        [Then(@"user can query to get all customers and must have (.*) record with the below data")]
        public void ThenUserCanQueryToGetAllCustomersAndMustHaveRecordWithTheBelowData(int customerNumber, Table table)
        {
            var response = Task.Run(async () => await Client.GetAsync(CustomerEndPoint + "/GetAll")).Result;
            Assert.True(response != null && response.StatusCode == HttpStatusCode.OK, "Get All Customer Integration Test Completed");
            var customers = response.ToResult<List<CustomerDTO>>().Result;
            Assert.Equal(customers.Data.Count, customerNumber);
            CustomerDTO customer = customers.Data.First();
            CustomerDTO expectedCustomer = table.CreateInstance<CustomerDTO>();

            Assert.Equal(customer.FirstName, expectedCustomer.FirstName);
            Assert.Equal(customer.LastName, expectedCustomer.LastName);
            Assert.Equal(customer.Email, expectedCustomer.Email);
            Assert.Equal(customer.BankAccountNumber, expectedCustomer.BankAccountNumber);
            Assert.Equal(customer.DateOfBirth, expectedCustomer.DateOfBirth);
            Assert.Equal(customer.Country, expectedCustomer.Country);

        }

        [When(@"user creates a customer with the same data by sending Create Customer Command through API")]
        public void WhenUserCreatesACustomerWithTheSameDataBySendingCreateCustomerCommandThroughAPI(Table table)
        {
            var customer = table.CreateInstance<CreateCustomerDTO>();
            ErrorResponse = Task.Run(async () => await Client.PostAsJsonAsync(CustomerEndPoint + "/Create", customer)).Result;
            
        }

        [Then(@"user must get error codes")]
        public void ThenUserMustGetErrorCodes(Table table)
        {
            Assert.Equal(((int)ErrorResponse.StatusCode).ToString(), table.Rows[0]["Codes"]);
        }

        [When(@"user creates a customer with an invalid mobile number, email, and bank account number")]
        public void WhenUserCreatesACustomerWithAnInvalidMobileNumberEmailAndBankAccountNumber(Table table)
        {
            var customer = table.CreateInstance<CreateCustomerDTO>();
            ErrorResponse = Task.Run(async () => await Client.PostAsJsonAsync(CustomerEndPoint + "/Create", customer)).Result;
        }

        [When(@"user edits customer with new data")]
        public void WhenUserEditsCustomerWithNewData(Table table)
        {
            var customer = table.CreateInstance<UpdateCustomerDTO>();
            var response = Task.Run(async () => await Client.PutAsJsonAsync(CustomerEndPoint + "/Edit", customer)).Result;
            var result = response.ToResult<int>().Result;
            Assert.True(result.Succeeded);
        }


        [When(@"user deletes customer by Id (.*)")]
        public void WhenUserDeletesCustomerById(int customerId)
        {
            var response = Task.Run(async () => await Client.DeleteAsync(CustomerEndPoint + $"/Delete/{customerId}")).Result;
            var result = response.ToResult<int>().Result;
            Assert.True(result.Succeeded);
        }

        [Then(@"user can query to get all customers and get (.*) records")]
        public void ThenUserCanQueryToGetAllCustomersAndGetRecords(int customerNumber)
        {
            var response = Task.Run(async () => await Client.GetAsync(CustomerEndPoint + "/GetAll")).Result;
            Assert.True(response != null && response.StatusCode == HttpStatusCode.OK, "Get All Customer Integration Test Completed");
            var customers = response.ToResult<List<CustomerDTO>>().Result;
            Assert.Equal(customers.Data.Count, customerNumber);
        }
    }
}
