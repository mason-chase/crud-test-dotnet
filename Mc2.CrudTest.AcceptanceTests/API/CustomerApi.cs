﻿using CrudTest.Services.Features.Marketing.Customers.CreateCustomer;
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

        public BddWebApplicationFactory Factory { get; } =  new BddWebApplicationFactory();

        private readonly HttpClient _httpClient;

        public CustomerApi()
        {
            _httpClient = Factory.CreateDefaultClient(new Uri("http://localhost:8080/api/Customers"));

            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, cert, chain, sslPolicyErrors) => true;


        }

        public async Task<HttpResponseMessage> CreateAsync()
        {
            var result = await _httpClient.PostAsJsonAsync("", CreateCustomerCommand);

            var content = await result.Content.ReadAsStringAsync();

            
            return result;
        }
    }
}