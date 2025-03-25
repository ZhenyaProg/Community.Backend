using Community.Application.Exceptions;
using Community.Core.Repositories.Todo;
using Community.Core.UseCases.Todo;
using FluentValidation;

namespace Community.Application.UseCases.Todo
{
    public class DeleteTodoByIdUseCase : IDeleteTodoByIdUseCase
    {
        private readonly IValidator<DeleteTodoCommand> _validator;
        private readonly IContainsTodoByIdRepository _containsRepository;
        private readonly IDeleteTodoByIdRepository _repository;

        public DeleteTodoByIdUseCase(
            IValidator<DeleteTodoCommand> validator,
            IContainsTodoByIdRepository containsRepository,
            IDeleteTodoByIdRepository repository)
        {
            _validator = validator;
            _containsRepository = containsRepository;
            _repository = repository;
        }

        public async Task Execute(DeleteTodoCommand command, CancellationToken token)
        {
            await _validator.ValidateAndThrowAsync(command, token);
            await _containsRepository.ThrowIfTodoNotFound(command.DeletedId, token);

            await _repository.Delete(command.DeletedId, token);
        }
    }
}