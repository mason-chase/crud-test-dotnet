
using Mc2.CrudTest.Core.ApplicationService.Customers.CommandHandlers;
using Mc2.CrudTest.Core.Domain.Customers.Commands;
using Mc2.CrudTest.Endpoints.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Endpoints.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {


        [HttpPost]
        public IActionResult Post([FromServices] CreateCustomerCommandHandler createCustomerHandler, CreateCustomerCommand request)
        {
            return RequestHandler.HandleRequest(request, createCustomerHandler.Handle);
        }

        [HttpPut]
        public IActionResult Put([FromServices] UpdateCustomerCommandHandler updateCustomerHandler, UpdateCustomerCommand request)
        {
            return RequestHandler.HandleRequest(request, updateCustomerHandler.Handle);
        }


        [HttpDelete]
        public IActionResult Delete([FromServices] DeleteCustomerCommandHandler deleteCustomerHandler, DeleteCustomerCommand request)
        {
            return RequestHandler.HandleRequest(request, deleteCustomerHandler.Handle);
        }
    }
}
