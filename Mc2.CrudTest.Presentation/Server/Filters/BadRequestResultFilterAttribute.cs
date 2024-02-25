using Mc2.CrudTest.Presentation.Server.Api;
using Mc2.CrudTest.Presentation.Server.DataAccess.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shared.Extensions.Extentions;

namespace Mc2.CrudTest.Presentation.Server.Filters;

public class BadRequestResultFilterAttribute : ActionFilterAttribute
{
    public override void OnResultExecuting(ResultExecutingContext context)
    {
        if (!(context.Result is BadRequestObjectResult badRequestObjectResult)) return;

        var modelState = context.ModelState;

        if (!modelState.IsValid)
        {
            var errors = new ValidationProblemDetails(modelState);

            var message = ApiResultStatusCode.BadRequest.ToDisplay();

            var apiResult =
                new ApiResult<IDictionary<string, string[]>>(false, ApiResultStatusCode.BadRequest, errors.Errors,
                    message);
            context.Result = new JsonResult(apiResult) { StatusCode = badRequestObjectResult.StatusCode };
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
        else
        {
            var apiResult = new ApiResult<object>(false, ApiResultStatusCode.BadRequest, badRequestObjectResult.Value,
                ApiResultStatusCode.BadRequest.ToDisplay());
            context.Result = new JsonResult(apiResult) { StatusCode = badRequestObjectResult.StatusCode };
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}