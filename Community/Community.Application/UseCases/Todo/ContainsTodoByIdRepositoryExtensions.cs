using Community.Application.Exceptions;
using Community.Core.Repositories.Todo;

namespace Community.Application.UseCases.Todo
{
    public static class ContainsTodoRepositoryExtensions
    {
        public static async Task ThrowIfTodoNotFound(
            this IContainsTodoByIdRepository repository,
            Guid id,
            CancellationToken token)
        {
            if(!await repository.Contains(id))
                throw new TodoNotFoundException(id);
        }
    }
}