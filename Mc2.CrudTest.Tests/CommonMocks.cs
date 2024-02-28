using Mc2.CrudTest.Application.Options;
using Microsoft.Extensions.Options;

namespace Mc2.CrudTest.Tests
{
    public class CommonMocks
    {
        public static IOptions<ApplicationErrors> ApplicationErros { get { return Options.Create(new ApplicationErrors()); } }
    }
}
