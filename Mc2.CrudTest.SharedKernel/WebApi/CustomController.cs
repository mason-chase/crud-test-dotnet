using Mc2.CrudTest.SharedKernel.Domain.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.SharedKernel.WebApi;

public abstract class CustomController : ControllerBase
{
    [NonAction]
    protected IActionResult FromServiceResult<T>(ServiceQueryResult<T> serviceResult)
    {
        if (serviceResult.HasResult)
        {
            return Ok(serviceResult.Result);
        }
        else
        {
            if (serviceResult.HasError)
            {
                return Problem(string.Join(Environment.NewLine, serviceResult.ErrorMessages));
            }
            else
            {
                return NotFound();
            }
        }

    }

    [NonAction]
    protected IActionResult FromServiceResult(ServiceCommandResult serviceResult)
    {

        if (serviceResult.WasSuccessfull)
        {
            if (string.IsNullOrEmpty(serviceResult.Id))
            {
                return NoContent();
            }
            else
            {
                var uri = new Uri(serviceResult.Uri, UriKind.Relative);
                return Created(uri, uri);
            }
        }
        else
        {
            return serviceResult.ErrorType switch
            {
                CommandErrorType.Validation => UnprocessableEntity(serviceResult.ErrorMessages),
                CommandErrorType.NotFound => NotFound(),
                CommandErrorType.General => Problem(string.Join(Environment.NewLine, serviceResult.ErrorMessages))
            };
        }

    }
}
