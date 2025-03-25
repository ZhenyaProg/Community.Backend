using Community.Application.Exceptions;
using Community.Core.UseCases.Todo;
using FluentValidation;

namespace Community.Application.Validators.Todo
{
    public class EditTodoCommandValidator : AbstractValidator<EditTodoCommand>
    {
        public EditTodoCommandValidator()
        {
            RuleFor(command => command.EditedId).NotNull();

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
