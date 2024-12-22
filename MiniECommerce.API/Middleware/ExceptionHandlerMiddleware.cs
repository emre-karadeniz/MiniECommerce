using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using MiniECommerce.Application.Core.Constants;
using MiniECommerce.Domain.Core;
using System.Net;
using System.Text.Json;

namespace MiniECommerce.Api.Middleware;

internal class ExceptionHandlerMiddleware(
    RequestDelegate next, 
    ILogger<ExceptionHandlerMiddleware> logger)
{
    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An exception occurred: {Message}", ex.Message);

            await HandleExceptionAsync(httpContext, ex);
        }
    }
    private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        (HttpStatusCode httpStatusCode, Result<NoContentDto> error) = GetHttpStatusCodeAndErrors(exception);

        httpContext.Response.ContentType = "application/json";

        httpContext.Response.StatusCode = (int)httpStatusCode;

        var serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        string response = JsonSerializer.Serialize(error, serializerOptions);

        await httpContext.Response.WriteAsync(response);
    }

    private static (HttpStatusCode httpStatusCode, Result<NoContentDto>) GetHttpStatusCodeAndErrors(Exception exception) =>
        exception switch
        {
            ValidationException validationException => (HttpStatusCode.BadRequest, Result<NoContentDto>.BadRequest(validationException.Errors.Select(x => x.ErrorMessage).ToList())),
            //DomainException domainException => (HttpStatusCode.BadRequest, new[] { domainException.Error }),
            _ => (HttpStatusCode.InternalServerError, Result<NoContentDto>.Error(Messages.Common.Error))
        };
}

internal static class ExceptionHandlerMiddlewareExtensions
{
    internal static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        => builder.UseMiddleware<ExceptionHandlerMiddleware>();
}