using Community.Core.Models;
using Community.Core.Repositories.Todo;
using Community.DataAccess.EF.Entities;
using Microsoft.EntityFrameworkCore;

namespace Community.DataAccess.EF.Repositories.Todo
{
    public class EditTodoRepository : IEditTodoRepository
    {
        private readonly ApplicationContext _dbContext;

        public EditTodoRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Edit(Guid editedId,
                                    string title,
                                    bool success,
                                    DateTime deadline,
                                    string description,
                                    CancellationToken token)
        {
            await _dbContext.Todos
                .Where(todo => todo.Id == editedId)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(t => t.Title, t => title)
                    .SetProperty(t => t.Success, t => success)
                    .SetProperty(t => t.Deadline, t => deadline)
                    .SetProperty(t => t.Description, t => description), token);
        }
    }
}