
using Mc2.CrudTest.Core.ApplicationService.Customers.CommandHandlers;
using Mc2.CrudTest.Core.Domain.Customers.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Endpoints.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {


        [HttpPost]
        public IActionResult Post([FromServices] CreateCustomerCommandHandler handler, CreateCustomerCommand request)
        {
            handler.Handle(request);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromServices] UpdateCustomerCommandHandler handler, UpdateCustomerCommand request)
        {
            handler.Handle(request);
            return Ok();
        }


        [HttpDelete]
        public IActionResult Delete([FromServices] DeleteCustomerCommandHandler handler, DeleteCustomerCommand request)
        {
            handler.Handle(request);
            return Ok();
        }
    }
}
