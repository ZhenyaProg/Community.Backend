using Community.Core.Models;

namespace Community.Core.Repositories.Todo
{
    public interface IGetTodoByPageRepository
    {
        Task<IEnumerable<TodoModel>> GetTodos(int page, int pageSize, CancellationToken token);
    }
}