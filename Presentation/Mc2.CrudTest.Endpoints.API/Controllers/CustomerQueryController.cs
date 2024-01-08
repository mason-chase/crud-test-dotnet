using Mc2.CrudTest.Core.Domain.Customers.Data;
using Mc2.CrudTest.Core.Domain.Customers.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Endpoints.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerQueryController : ControllerBase
    {
        private readonly ICustomerQueryRepository _customerQueryRepository;

        public CustomerQueryController(ICustomerQueryRepository customerQueryService)
        {
            _customerQueryRepository = customerQueryService;
        }

        [Route("Get")]
        [HttpGet]
        public IActionResult Get([FromQuery] GetCustomerByIdQuery request)
        {
            return new OkObjectResult(_customerQueryRepository.Query(request));
        }


        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll([FromQuery] GetAllCustomersQuery request)
        {
            return new OkObjectResult(_customerQueryRepository.Query(request));
        }

    }
}
