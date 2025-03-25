using Community.Core.Models;

namespace Community.Core.UseCases.Todo
{
    public interface IGetTodoByIdUseCase
    {
        Task<TodoModel> Execute(GetTodoByIdQuery query, CancellationToken token);
    }
}