using Community.Core.Models;

namespace Community.Core.Repositories.Todo
{
    public interface IGetTodoByIdRepository
    {
        Task<TodoModel> GetById(Guid id, CancellationToken token);
    }
}