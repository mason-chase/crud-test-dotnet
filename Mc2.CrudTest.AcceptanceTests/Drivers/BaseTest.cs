using Mc2.CrudTest.Presentation;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.AcceptanceTests.Drivers
{
    public abstract class BaseTest
    {
        public HttpClient Client { get; set; }
        public string ApiUri { get; set; }

        public BaseTest()
        {
            var appFactory = new WebApplicationFactory<Program>();
            Client = appFactory.CreateClient();
            ApiUri = Client?.BaseAddress?.AbsoluteUri;
        }
    }
}
