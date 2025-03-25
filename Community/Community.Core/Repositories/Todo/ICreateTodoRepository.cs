namespace Community.Core.Repositories.Todo
{
    public interface ICreateTodoRepository
    {
        Task Create(
            string title,
            bool success,
            DateTime deadline,
            string description,
            CancellationToken token);
    }
}