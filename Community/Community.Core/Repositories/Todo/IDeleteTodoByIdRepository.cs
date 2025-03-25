namespace Community.Core.Repositories.Todo
{
    public interface IDeleteTodoByIdRepository
    {
        Task Delete(Guid id, CancellationToken token);
    }
}