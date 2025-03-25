using Community.Core.Models;

namespace Community.Core.Repositories.Todo
{
    public interface IEditTodoRepository
    {
        Task Edit(
            Guid editedId,
            string title,
            bool success,
            DateTime deadline,
            string description,
            CancellationToken token);
    }
}