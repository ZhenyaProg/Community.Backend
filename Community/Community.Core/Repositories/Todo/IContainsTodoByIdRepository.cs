namespace Community.Core.Repositories.Todo
{
    public interface IContainsTodoByIdRepository
    {
        Task<bool> Contains(Guid id);
    }
}