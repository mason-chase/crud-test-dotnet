using Mc2.CrudTest.Application.Services.Customers.Command.EditCustomer;
using Mc2.CrudTest.Application.Services.Customers.Command.RegisterCustomer;
using Mc2.CrudTest.Application.Services.Customers.Command.RemoveCustomer;
using Mc2.CrudTest.Application.Services.Customers.Query.GetCustomerByID;
using Mc2.CrudTest.Application.Services.Customers.Query.GetCustomers;
using Mc2.CrudTest.Domain.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IGetCustomersService _getCustomersService;
        private readonly IRegisterCustomerService _registerCustomerService;
        private readonly IEditCustomerService _editCustomerService;
        private readonly IGetCustomerByID _getCustomerByID;
        private readonly IRemoveCustomer _removeCustomer;
        public CustomerController(IGetCustomersService getCustomersService,
            IRegisterCustomerService registerCustomerService,
            IEditCustomerService editCustomerService,
            IGetCustomerByID getCustomerByID,
            IRemoveCustomer removeCustomer)
        {
            _getCustomersService = getCustomersService;
            _registerCustomerService = registerCustomerService;
            _editCustomerService = editCustomerService;
            _getCustomerByID = getCustomerByID;
            _removeCustomer = removeCustomer;
        }

        [HttpGet]
        public IActionResult GetCustomerList()
        {
            try
            {
                return Ok(_getCustomersService.Execute());
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetCustomerByID(long id)
        {

            try
            {
                return Ok(_getCustomerByID.Execute(id));
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CustomerDto reqDTO)
        {
            try
            {
                return Ok(_registerCustomerService.Execute(reqDTO));

            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(long id, [FromBody] EditCustomerDto reqDTO)
        {

            if (id == null)
            {
                return BadRequest("Mismatched customer ID");
            }

            // Perform validation and error handling if needed

            try
            {
                var updatedCustomer = new EditCustomerDto
                {
                    FirstName = reqDTO.FirstName,
                    LastName = reqDTO.LastName,
                    DateOfBirth = reqDTO.DateOfBirth,
                    PhoneNumber = reqDTO.PhoneNumber,
                    Email = reqDTO.Email,
                    BankAccountNumber = reqDTO.BankAccountNumber
                };
                return Ok(_editCustomerService.Execute(id, updatedCustomer));
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult RemoveCustomer(long id)
        {
            try
            {
                return Ok(_removeCustomer.Execute(id));

            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
