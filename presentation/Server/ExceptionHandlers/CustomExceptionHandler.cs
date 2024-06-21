using System.ComponentModel.DataAnnotations;
using Mc2.CrudTest.Shared.BuildingBlocks.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Extensions;

namespace Mc2.CrudTest.Presentation.Server.ExceptionHandlers;

public class CustomExceptionHandler
{
    private readonly ILogger<CustomExceptionHandler> _logger;

    public CustomExceptionHandler(ILogger<CustomExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async Task<bool> HandleAsync(HttpContext context, IExceptionHandlerFeature exceptionFeature)
    {
        Exception exception = exceptionFeature.Error;
        _logger.LogError(exception, "Error Message: {ExceptionMessage}, Time of occurrence {Time}", exception.Message, DateTime.UtcNow);

        (string Detail, int StatusCode) details = exception switch
        {
            ValidationException =>
            (
                exception.Message,
                context.Response.StatusCode = StatusCodes.Status400BadRequest
            ),
            BadRequestException =>
            (
                exception.Message,
                context.Response.StatusCode = StatusCodes.Status400BadRequest
            ),
            NotFoundException =>
            (
                exception.Message,
                context.Response.StatusCode = StatusCodes.Status404NotFound
            ),
            _ =>
            (
                exception.Message,
                context.Response.StatusCode = StatusCodes.Status500InternalServerError
            )
        };

        ResponseFailed problemDetails = new ResponseFailed
        {
            Path = context.Request.GetEncodedPathAndQuery(),
            Message = details.Detail,
            TraceId = context.TraceIdentifier,
        };

        context.Response.StatusCode = details.StatusCode;
        await context.Response.WriteAsJsonAsync(problemDetails).ConfigureAwait(false);
        return true;
    }

    public static void Run(IApplicationBuilder appBuilder)
    {
        appBuilder.Run(async httpContext =>
        {
            CustomExceptionHandler handler = httpContext.RequestServices.GetRequiredService<CustomExceptionHandler>();
            IExceptionHandlerFeature? feature = httpContext.Features.Get<IExceptionHandlerFeature>();
            if (feature == null) return;
            await handler.HandleAsync(httpContext, feature);
        });
    }
}