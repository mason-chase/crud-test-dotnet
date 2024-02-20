using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.AcceptanceTests.API
{
    public class CustomerApi
    {
        public ulong PhoneNumber { get; set; }

        private readonly HttpClient _httpClient;

        public CustomerApi()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:8080/api/Customers");

            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, cert, chain, sslPolicyErrors) => true;
        }

        public async Task<HttpResponseMessage> CreateAsync()
        {
            var result = await _httpClient.PostAsJsonAsync("", this);

            return result;
        }
    }
}
