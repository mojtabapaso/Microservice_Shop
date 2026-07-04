using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using FluentValidation;
using Microservice.Core.Exceptions;

namespace Microservice.Core.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger<ExceptionHandlingMiddleware> logger;
    private readonly IHostEnvironment env;

    public ExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger,
        IHostEnvironment env)
    {
        this.next = next;
        this.logger = logger;
        this.env = env;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unhandled exception occurred while processing the request.");

            var statusCode = ex switch
            {
                ValidationException => StatusCodes.Status400BadRequest,
                DomainException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };
            
            var problem = new ProblemDetails
            {
                Status = statusCode,
                Title = ex.Message,
                Instance = context.Request.Path,
            };

            if (env.IsDevelopment())
            {
                problem.Title = ex.Message;
                problem.Detail = ex.StackTrace;
            }
            else
            {
                problem.Title = ex.Message;
                problem.Detail = "An unexpected error occurred. Please try again later.";
            }

            context.Response.StatusCode = problem.Status.Value;
            context.Response.ContentType = "application/problem+json";
            await context.Response.WriteAsJsonAsync(problem);
        }
    }
}