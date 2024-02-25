using Mc2.CrudTest.Presentation.Server.Api;
using Mc2.CrudTest.Presentation.Server.DataAccess.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Mc2.CrudTest.Presentation.Server.Filters;

public class ContentResultFilterAttribute : ResultFilterAttribute
{
    public override void OnResultExecuting(ResultExecutingContext context)
    {
        if (!(context.Result is ContentResult contentResult)) return;
        var apiResult = new ApiResult(true, ApiResultStatusCode.Success, contentResult.Content);
        context.Result = new JsonResult(apiResult) { StatusCode = contentResult.StatusCode };
    }
}