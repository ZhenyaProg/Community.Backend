using FluentValidation;
using Community.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Community.API.Middlewares
{
    public static class ProblemDetailsFactoryExtensions
    {
        public static ProblemDetails CreateFrom(
            this ProblemDetailsFactory detailsFactory,
            HttpContext httpContext,
            DomainException exception)
        {
            return detailsFactory.CreateProblemDetails(
                httpContext,
                exception.ErrorCode switch
                {
                    DomainErrorCodes.Gone => StatusCodes.Status410Gone,
                    _ => StatusCodes.Status500InternalServerError
                },
                exception.Message);
        }

        public static ProblemDetails CreateFrom(
            this ProblemDetailsFactory detailsFactory,
            HttpContext httpContext,
            ValidationException exception)
        {
            ModelStateDictionary modelStateDictionary = new ModelStateDictionary();

            foreach (var error in exception.Errors)
                modelStateDictionary.AddModelError(error.PropertyName, error.ErrorCode);

            return detailsFactory.CreateValidationProblemDetails(
                httpContext,
                modelStateDictionary,
                StatusCodes.Status400BadRequest,
                "Validation failed");
        }
    }
}