using Application.Customers.Commands;
using Core.Models;
using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using TechTalk.SpecFlow.Assist;

namespace Mc2.CrudTest.AcceptanceTests.Steps
{
    [Binding]
    public sealed class CustomerManagerStepDefinitions
    {
        private readonly HttpClient _httpClient;
        private readonly ScenarioContext _scenarioContext;
        public CustomerManagerStepDefinitions(HttpClient httpClient, ScenarioContext scenarioContext)
        {
            _httpClient = httpClient;
            _scenarioContext = scenarioContext;
        }


        [When(@"I create customers with the following details")]
        public async Task WhenISendARequestToCreateANewCustomer(Table table)
        {
            var createCustomerRequests = table.CreateSet<CreateCustomerRequest>();
            var createCustomers = new List<int>();
            foreach (var item in createCustomerRequests)
            {
                var response = await _httpClient.PostAsJsonAsync("Create", item);
                var id = await response.Content.ReadFromJsonAsync<int>();
                createCustomers.Add(id);
            }
            _scenarioContext.Add("CreatedCustomers", createCustomers);
        }

        [Then(@"the customer should be created successfully")]
        public async Task ThenTheCustomerShouldBeCreatedSuccessfully()
        {
            var createdCustomers = _scenarioContext.Get<List<int>>("CreatedCustomers");
            foreach (var item in createdCustomers)
            {
                var response = await _httpClient.GetFromJsonAsync<Customer>($"GetById/{item}");
                item.Should().Be(response.Id);
            }
        }

        [When(@"I create customers with the following details with duplicate email")]
        public async Task WhenICreateCustomersWithTheFollowingDetailsWithDuplicateEmail(Table table)
        {
            var createCustomerRequests = table.CreateSet<CreateCustomerRequest>();
            var errorMessages = new List<string>();
            foreach (var item in createCustomerRequests)
            {
                var response = await _httpClient.PostAsJsonAsync("Create", item);
                var message = await response.Content.ReadAsStringAsync();
                errorMessages.Add(message);
            }
            _scenarioContext.Add("DuplicateEmailValidationErrorMessage", errorMessages);
        }


        [Then(@"the second request with duplicate Email should fail with a validation error")]
        public void ThenTheSecondRequestWithDuplicateEmailShouldFailWithAValidationError()
        {
            var errorMessages = _scenarioContext.Get<List<string>>("DuplicateEmailValidationErrorMessage");
            errorMessages.Contains("Email already exists.");
        }

        [When(@"I create customers with the following details with duplicate detail")]
        public async Task WhenICreateCustomersWithTheFollowingDetailsWithDuplicateDetail(Table table)
        {
            var createCustomerRequests = table.CreateSet<CreateCustomerRequest>();
            var errorMessages = new List<string>();
            foreach (var item in createCustomerRequests)
            {
                var response = await _httpClient.PostAsJsonAsync("Create", item);
                var message = await response.Content.ReadAsStringAsync();
                errorMessages.Add(message);
            }
            _scenarioContext.Add("DuplicateDetailValidationErrorMessage", errorMessages);
        }

        [Then(@"the second request with duplicate detail should fail with a validation error")]
        public void ThenTheSecondRequestWithDuplicateDetailShouldFailWithAValidationError()
        {
            var errorMessages = _scenarioContext.Get<List<string>>("DuplicateDetailValidationErrorMessage");
            errorMessages.Contains("Customer with the same details already exists.");
        }


        [When(@"I send a request with invalid PhoneNumber to create a new customer")]
        public async Task WhenISendARequestWithInvalidPhoneNumberToCreateANewCustomer(Table table)
        {
            var createCustomerRequests = table.CreateSet<CreateCustomerRequest>();
            var errorMessages = new List<string>();
            foreach (var item in createCustomerRequests)
            {
                var response = await _httpClient.PostAsJsonAsync("Create", item);
                var message = await response.Content.ReadAsStringAsync();
                errorMessages.Add(message);
            }
            _scenarioContext.Add("PhoneNumberValidationErrorMessage", errorMessages);
        }

        [When(@"I send a request with invalid Email to create a new customer")]
        public async Task WhenISendARequestWithInvalidEmailToCreateANewCustomer(Table table)
        {
            var createCustomerRequests = table.CreateSet<CreateCustomerRequest>();
            var errorMessages = new List<string>();
            foreach (var item in createCustomerRequests)
            {
                var response = await _httpClient.PostAsJsonAsync("Create", item);
                var message = await response.Content.ReadAsStringAsync();
                errorMessages.Add(message);
            }
            _scenarioContext.Add("EmailValidationErrorMessage", errorMessages);
        }

        [When(@"I send a request with invalid BankAccountNumber to create a new customer")]
        public async Task WhenISendARequestWithInvalidBankAccountNumberToCreateANewCustomer(Table table)
        {
            var createCustomerRequests = table.CreateSet<CreateCustomerRequest>();
            var errorMessages = new List<string>();
            foreach (var item in createCustomerRequests)
            {
                var response = await _httpClient.PostAsJsonAsync("Create", item);
                var message = await response.Content.ReadAsStringAsync();
                errorMessages.Add(message);
            }
            _scenarioContext.Add("BankAccountNumberValidationErrorMessage", errorMessages);
        }

        [Then(@"the request should fail with a validation error for PhoneNumber")]
        public void ThenTheRequestShouldFailWithAValidationErrorForPhoneNumber()
        {
            var errorMessages = _scenarioContext.Get<List<string>>("PhoneNumberValidationErrorMessage");
            errorMessages.Contains("Please Enter a Valid PhoneNumber");
        }

        [Then(@"the request should fail with a validation error for Email")]
        public void ThenTheRequestShouldFailWithAValidationErrorForEmail()
        {
            var errorMessages = _scenarioContext.Get<List<string>>("EmailValidationErrorMessage");
            errorMessages.Contains("Please Enter a Valid Email");
        }

        [Then(@"the request should fail with a validation error for BankAccountNumber")]
        public void ThenTheRequestShouldFailWithAValidationErrorForBankAccountNumber()
        {
            var errorMessages = _scenarioContext.Get<List<string>>("BankAccountNumberValidationErrorMessage");
            errorMessages.Contains("Please Enter a Valid BankAccountNumber");
        }

        [Given(@"there is an existing customer with the following details")]
        public async Task GivenThereIsAnExistingCustomerWithTheFollowingDetails(Table table)
        {
            var createCustomerRequests = table.CreateSet<CreateCustomerRequest>();
            var createCustomers = new List<int>();
            foreach (var item in createCustomerRequests)
            {
                var response = await _httpClient.PostAsJsonAsync("Create", item);
                var id = await response.Content.ReadFromJsonAsync<int>();
                createCustomers.Add(id);
            }
            _scenarioContext.Add("CreatedCustomersForUpdate", createCustomers);
        }

        [When(@"I send a request to update the customer with following detail")]
        public async Task WhenISendARequestToUpdateTheCustomerWithFollowingDetail(Table table)
        {
            var createdCustomers = _scenarioContext.Get<List<int>>("CreatedCustomersForUpdate");
            var updateCustomerRequests = table.CreateSet<UpdateCustomerRequest>();
            foreach (var item in updateCustomerRequests)
            {
                item.Id = createdCustomers[0];
                _ = await _httpClient.PutAsJsonAsync("Update", item);
            }
        }

        [Then(@"the customer should be updated successfully")]
        public async Task ThenTheCustomerShouldBeUpdatedSuccessfully()
        {
            var createdCustomers = _scenarioContext.Get<List<int>>("CreatedCustomersForUpdate");
            var response = await _httpClient.GetFromJsonAsync<Customer>($"GetById/{createdCustomers[0]}");
            response.FirstName.Should().Be("Janet");
        }

        [When(@"I send a request to update the customer with invalid PhoneNumber with the following details")]
        public async Task WhenISendARequestToUpdateTheCustomerWithInvalidPhoneNumberWithTheFollowingDetails(Table table)
        {
            var createCustomerRequests = table.CreateSet<UpdateCustomerRequest>();
            var errorMessages = new List<string>();
            foreach (var item in createCustomerRequests)
            {
                var response = await _httpClient.PutAsJsonAsync("Update", item);
                var message = await response.Content.ReadAsStringAsync();
                errorMessages.Add(message);
            }
            _scenarioContext.Add("PhoneNumberValidationErrorMessage", errorMessages);
        }

        [When(@"I send a request to update the customer with invalid Email with the following details")]
        public async Task WhenISendARequestToUpdateTheCustomerWithInvalidEmailWithTheFollowingDetails(Table table)
        {
            var createCustomerRequests = table.CreateSet<UpdateCustomerRequest>();
            var errorMessages = new List<string>();
            foreach (var item in createCustomerRequests)
            {
                var response = await _httpClient.PutAsJsonAsync("Update", item);
                var message = await response.Content.ReadAsStringAsync();
                errorMessages.Add(message);
            }
            _scenarioContext.Add("EmailValidationErrorMessage", errorMessages);
        }

        [When(@"I send a request to update the customer with invalid BankAccountNumber with the following details")]
        public async Task WhenISendARequestToUpdateTheCustomerWithInvalidBankAccountNumberWithTheFollowingDetails(Table table)
        {
            var createCustomerRequests = table.CreateSet<UpdateCustomerRequest>();
            var errorMessages = new List<string>();
            foreach (var item in createCustomerRequests)
            {
                var response = await _httpClient.PutAsJsonAsync("Update", item);
                var message = await response.Content.ReadAsStringAsync();
                errorMessages.Add(message);
            }
            _scenarioContext.Add("BankAccountNumberValidationErrorMessage", errorMessages);
        }

        [When(@"I send a request to get the customer by ID")]
        public async Task WhenISendARequestToGetTheCustomerByID()
        {
            var createdCustomers = _scenarioContext.Get<List<int>>("CreatedCustomersForUpdate");
            var returnedCustomers = new List<Customer>();
            foreach (var item in createdCustomers)
            {
                var response = await _httpClient.GetFromJsonAsync<Customer>($"GetById/{item}");
                returnedCustomers.Add(response);
            }
            _scenarioContext.Add("ReturnedCustomers", returnedCustomers);
        }

        [Then(@"the customer details should be returned successfully")]
        public void ThenTheCustomerDetailsShouldBeReturnedSuccessfully()
        {
            var returnedCustomers = _scenarioContext.Get<List<Customer>>("ReturnedCustomers");
            returnedCustomers.Should().NotBeNull();
        }

        [When(@"I send a request to get all customers")]
        public async Task WhenISendARequestToGetAllCustomers()
        {
            var returnedCustomers = await _httpClient.GetFromJsonAsync<List<Customer>>("GetAll");
            _scenarioContext.Add("ReturnedCustomersForGetAll", returnedCustomers);
        }

        [Then(@"the list of customers should be returned successfully")]
        public void ThenTheListOfCustomersShouldBeReturnedSuccessfully()
        {
            var returnedCustomers = _scenarioContext.Get<List<Customer>>("ReturnedCustomersForGetAll");
            returnedCustomers.Should().NotBeNull();
        }

        [When(@"I send a request to delete the customer by ID")]
        public async Task WhenISendARequestToDeleteTheCustomerByID()
        {
            var createdCustomers = _scenarioContext.Get<List<int>>("CreatedCustomersForUpdate");
            foreach (var item in createdCustomers)
            {
                var response = await _httpClient.DeleteAsync($"DeleteById/{item}");
                _ = await response.Content.ReadAsStringAsync();
            }
        }

        [Then(@"the customer should be deleted successfully")]
        public async Task ThenTheCustomerShouldBeDeletedSuccessfully()
        {
            var createdCustomers = _scenarioContext.Get<List<int>>("CreatedCustomersForUpdate");
            foreach (var item in createdCustomers)
            {
                var response = await _httpClient.GetAsync($"GetById/{item}");
                response.StatusCode.Should().Be(HttpStatusCode.NotFound);
            }
        }



    }
}
