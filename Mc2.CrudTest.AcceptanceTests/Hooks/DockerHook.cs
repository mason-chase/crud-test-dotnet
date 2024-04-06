using BoDi;
using Ductus.FluentDocker.Builders;
using Ductus.FluentDocker.Services;
using Microsoft.Extensions.Configuration;

namespace Mc2.CrudTest.AcceptanceTests.Hooks
{
    [Binding]
    public class DockerHook
    {
        private static ICompositeService _compositeService;
        private readonly IObjectContainer _objectContainer;

        public DockerHook(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void DockerComposeUp()
        {
            var config = LoadConfiguration();

            var dockerComposeFileName = config["DockerComposeFileName"];
            var dockerComposePath = GetDockerComposeLocation(dockerComposeFileName);

            var confirmationUrl = config["Customer.Api:BaseAddress"];
            _compositeService = new Builder()
                .UseContainer()
                .UseCompose()
                .FromFile(dockerComposePath)
                .RemoveOrphans()
                .WaitForHttp("webapi", $"{confirmationUrl}/customer",
                continuation: (response, _) => response.Code != System.Net.HttpStatusCode.OK ? 2000 : 0)
                .Build().Start();

        }

        [AfterTestRun]
        public static void DockerComposeDown()
        {
            _compositeService.Stop();
            _compositeService.Dispose();
        }

        [BeforeScenario]
        public void AddHttpClient()
        {
            var config = LoadConfiguration();
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(config["Customer.Api:BaseAddress"])
            };
            _objectContainer.RegisterInstanceAs(httpClient);
        }

        private static IConfiguration LoadConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        private static string GetDockerComposeLocation(string dockerComposeFileName)
        {
            var directory = Directory.GetCurrentDirectory();
            while (!Directory.EnumerateFiles(directory, "*.yml").Any(_ => _.EndsWith(dockerComposeFileName)))
            {
                directory = directory.Substring(0, directory.LastIndexOf(Path.DirectorySeparatorChar));
            }
            return Path.Combine(directory, dockerComposeFileName);
        }
    }
}