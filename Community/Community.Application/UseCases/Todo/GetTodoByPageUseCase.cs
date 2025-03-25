using Community.Core.Models;
using Community.Core.Repositories.Todo;
using Community.Core.UseCases.Todo;
using FluentValidation;

namespace Community.Application.UseCases.Todo
{
    public class GetTodoByPageUseCase : IGetTodoByPageUseCase
    {
        private readonly IValidator<GetTodoByPageQuery> _validator;
        private readonly IGetTodoByPageRepository _repository;

        public GetTodoByPageUseCase(
            IValidator<GetTodoByPageQuery> validator,
            IGetTodoByPageRepository repository)
        {
            _validator = validator;
            _repository = repository;
        }

        public async Task<IEnumerable<TodoModel>> Execute(
            GetTodoByPageQuery query,
            CancellationToken token)
        {
            await _validator.ValidateAndThrowAsync(query, token);

            return await _repository.GetTodos(query.Page, query.PageSize, token);
        }
    }
}