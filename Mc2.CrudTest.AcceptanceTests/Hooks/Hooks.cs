using Microsoft.Extensions.Hosting;
using System;
using TechTalk.SpecFlow;
using CrudTest.API;
namespace Mc2.CrudTest.AcceptanceTests.Hooks
{
    [Binding]
    public class Hooks
    {
        private static IHost? _host;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            _host = Program.CreateHostBuilder(null!).Build();

            _host.Start();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            _host!.StopAsync().Wait();
        }
    }
}