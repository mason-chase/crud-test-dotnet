using CrudTest.Models.Entities.Marketing.Customers;
using CrudTest.Services.Features.Marketing.Customers.CreateCustomer;
using CrudTest.Services.Features.Marketing.Customers.DeleteCustomer;
using CrudTest.Services.Features.Marketing.Customers.DTOs;
using CrudTest.Services.Features.Marketing.Customers.GetAllCustomers;
using CrudTest.Services.Features.Marketing.Customers.UpdateCustomer;
using Mc2.CrudTest.AcceptanceTests.Factories;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mc2.CrudTest.AcceptanceTests.API
{
    public class CustomerApi
    {
        public CreateCustomerCommand CreateCustomerCommand { get; } = new CreateCustomerCommand();
        public UpdateCustomerCommand UpdateCustomerCommand { get; } = new UpdateCustomerCommand();

        public BddWebApplicationFactory Factory { get; } =  new BddWebApplicationFactory();

        private readonly HttpClient _httpClient;

        public CustomerApi()
        {
            _httpClient = Factory.CreateDefaultClient(new Uri("http://localhost:8080/api/"));

            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, cert, chain, sslPolicyErrors) => true;


        }

        public async Task<HttpResponseMessage> CreateAsync()
        {
            var result = await _httpClient.PostAsJsonAsync("Customers", CreateCustomerCommand);

            return result;
        }

        public async Task<List<CustomerResponseDto>> GetAllAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<GetAllCustomersResponse>("Customers");

            return result!.Data!;
        }

        public async Task<DeleteCustomerResponse> DeleteAsync(Guid customerId)
        {
            var result = await _httpClient.DeleteFromJsonAsync<DeleteCustomerResponse>($"Customers/{customerId}");

            return result!;
        }

        public async Task<UpdateCustomerResponse> UpdateAsync(Guid customerId)
        {
            var result = await _httpClient.PutAsJsonAsync($"Customers/{customerId}",UpdateCustomerCommand);

            var content = await result.Content.ReadAsStringAsync();

            var jsonObj = JsonSerializer.Deserialize<UpdateCustomerResponse>(content,new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive  = true
            });

            return jsonObj!;
        }
    }
}
