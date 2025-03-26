using Community.Application.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Community.API.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(
            HttpContext httpContext,
            ProblemDetailsFactory problemDetailsFactory)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                ProblemDetails problemDetails;
                switch (ex)
                {
                    case ValidationException validationException:
                        problemDetails = problemDetailsFactory.CreateFrom(httpContext, validationException);
                        break;
                    case DomainException domainException:
                        problemDetails = problemDetailsFactory.CreateFrom(httpContext, domainException);
                        break;
                    default:
                        problemDetails = problemDetailsFactory.CreateProblemDetails(httpContext, StatusCodes.Status500InternalServerError, "Unhandled error", detail: ex.Message);
                        break;
                }

                httpContext.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;
                await httpContext.Response.WriteAsJsonAsync(problemDetails, problemDetails.GetType());
            }
        }
    }
}