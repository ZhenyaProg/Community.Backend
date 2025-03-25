using Community.Application.Exceptions;
using Community.Core.UseCases.Todo;
using FluentValidation;

namespace Community.Application.Validators.Todo
{
    public class GetTodoByIdQueryValidator : AbstractValidator<GetTodoByIdQuery>
    {
        public GetTodoByIdQueryValidator()
        {
            RuleFor(query => query.Id)
                .NotNull()
                .WithErrorCode(ValidationErrorCodes.Empty);
        }
    }
}