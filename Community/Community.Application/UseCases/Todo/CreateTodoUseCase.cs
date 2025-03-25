using Community.Core.Repositories.Todo;
using Community.Core.UseCases.Todo;
using FluentValidation;

namespace Community.Application.UseCases.Todo
{
    public class CreateTodoUseCase : ICreateTodoUseCase
    {
        private readonly IValidator<CreateTodoCommand> _validator;
        private readonly ICreateTodoRepository _repository;

        public CreateTodoUseCase(
            IValidator<CreateTodoCommand> validator,
            ICreateTodoRepository repository)
        {
            _validator = validator;
            _repository = repository;
        }

        public async Task Execute(CreateTodoCommand command, CancellationToken token)
        {
            await _validator.ValidateAndThrowAsync(command, token);

            DateTime deadline = DateTime.Parse(command.Deadline);
            await _repository.Create(command.Title, command.Success, deadline, command.Description, token);
        }
    }
}