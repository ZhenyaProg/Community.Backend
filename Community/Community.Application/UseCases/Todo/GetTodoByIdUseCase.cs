using Community.Application.Exceptions;
using Community.Core.Models;
using Community.Core.Repositories.Todo;
using Community.Core.UseCases.Todo;
using FluentValidation;

namespace Community.Application.UseCases.Todo
{
    public class GetTodoByIdUseCase : IGetTodoByIdUseCase
    {
        private readonly IValidator<GetTodoByIdQuery> _validator;
        private readonly IGetTodoByIdRepository _repository;
        private readonly IContainsTodoByIdRepository _containsRepository;

        public GetTodoByIdUseCase(
            IValidator<GetTodoByIdQuery> validator,
            IGetTodoByIdRepository repository,
            IContainsTodoByIdRepository containsRepository)
        {
            _validator = validator;
            _repository = repository;
            _containsRepository = containsRepository;
        }

        public async Task<TodoModel> Execute(GetTodoByIdQuery query, CancellationToken token)
        {
            await _validator.ValidateAndThrowAsync(query, token);
            await _containsRepository.ThrowIfTodoNotFound(query.Id, token);

            TodoModel model = await _repository.GetById(query.Id, token);
            return model;
        }
    }
}