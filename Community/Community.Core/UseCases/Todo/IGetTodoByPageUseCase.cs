using Community.Core.Models;

namespace Community.Core.UseCases.Todo
{
    public interface IGetTodoByPageUseCase
    {
        Task<IEnumerable<TodoModel>> Execute(GetTodoByPageQuery query, CancellationToken token);
    }
}