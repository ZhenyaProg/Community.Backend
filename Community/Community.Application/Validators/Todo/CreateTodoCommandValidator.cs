using Community.Application.Exceptions;
using Community.Core.UseCases.Todo;
using FluentValidation;

namespace Community.Application.Validators.Todo
{
    public class CreateTodoCommandValidator : AbstractValidator<CreateTodoCommand>
    {
        public CreateTodoCommandValidator()
        {
            RuleFor(command => command.Title)
                .MinimumLength(5)
                .WithErrorCode(ValidationErrorCodes.Tooshort)
                .MaximumLength(20)
                .WithErrorCode(ValidationErrorCodes.Toolong);

            RuleFor(command => command.Description)
                .MaximumLength(100)
                .WithErrorCode(ValidationErrorCodes.Toolong);

            RuleFor(command => command.Deadline)
                .Must(deadlineStr =>
                    DateTime.TryParse(deadlineStr, out var deadline) &&
                    deadline > DateTime.Now
                )
                .WithErrorCode(ValidationErrorCodes.Invalid);
        }
    }
}