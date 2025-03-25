using Community.Application.Exceptions;
using Community.Core.UseCases.Todo;
using FluentValidation;

namespace Community.Application.Validators.Todo
{
    public class DeleteTodoByIdCommandValidator : AbstractValidator<DeleteTodoCommand>
    {
        public DeleteTodoByIdCommandValidator()
        {
            RuleFor(cpmmand => cpmmand.DeletedId)
                .NotNull()
                .WithErrorCode(ValidationErrorCodes.Empty);
        }
    }
}