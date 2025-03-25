using Community.Application.Exceptions;
using Community.Core.Repositories.Todo;
using Community.Core.UseCases.Todo;
using FluentValidation;

namespace Community.Application.UseCases.Todo
{
    public class EditTodoByIdUseCase : IEditTodoUseCase
    {
        private readonly IValidator<EditTodoCommand> _validator;
        private readonly IContainsTodoByIdRepository _containsRepository;
        private readonly IEditTodoRepository _repository;

        public EditTodoByIdUseCase(
            IValidator<EditTodoCommand> validator,
            IContainsTodoByIdRepository containsRepository,
            IEditTodoRepository repository)
        {
            _validator = validator;
            _containsRepository = containsRepository;
            _repository = repository;
        }

        public async Task Execute(EditTodoCommand query, CancellationToken token)
        {
            await _validator.ValidateAndThrowAsync(query, token);
            await _containsRepository.ThrowIfTodoNotFound(query.EditedId, token);

            DateTime deadline = DateTime.Parse(query.Deadline);
            await _repository.Edit(query.EditedId, query.Title, query.Success, deadline, query.Description, token);
        }
    }
}