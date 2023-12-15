using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Application.DTO;
using Mc2.CrudTest.Application.Queires;
using Mc2.CrudTest.Shared.Abstraction.Command;
using Mc2.CrudTest.Shared.Abstraction.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Api.Controllers
{
    public class CustomerManager : BaseController
    {
        private readonly ICommandDistpatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public CustomerManager(ICommandDistpatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        //Take
        [HttpGet]
        public async Task<ActionResult<CustomerDto>> Get([FromQuery] GetCustomerById query)
        {
            var result = await _queryDispatcher.Query(query);
            return OkOrNotFound(result);
        }

        //Add
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddCustomer command)
        {
            await _commandDispatcher.Dispatch(command);
            return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
        }

        //Edit
        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] EditCustomer command)
        {
            await _commandDispatcher.Dispatch(command);
            return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
        }

        //Remove
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] RemoveCustomer command)
        {
            await _commandDispatcher.Dispatch(command);
            return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
        }
    }
}
