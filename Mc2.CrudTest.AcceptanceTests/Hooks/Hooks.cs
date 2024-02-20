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
            
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            
        }
    }
}