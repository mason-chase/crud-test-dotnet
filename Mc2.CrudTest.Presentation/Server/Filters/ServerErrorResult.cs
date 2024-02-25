using Mc2.CrudTest.Presentation.Server.Api;
using Mc2.CrudTest.Presentation.Server.DataAccess.Enum;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Server.Filters;

public class ServerErrorResult : IActionResult
{
    public ServerErrorResult(string message)
    {
        Message = message;
    }

    public string Message { get; }

    public async Task ExecuteResultAsync(ActionContext context)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        var response = new ApiResult(false, ApiResultStatusCode.ServerError, Message);
        await context.HttpContext.Response.WriteAsJsonAsync(response);
    }
}