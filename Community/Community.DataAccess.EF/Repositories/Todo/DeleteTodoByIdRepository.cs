using Community.Core.Repositories.Todo;
using Microsoft.EntityFrameworkCore;

namespace Community.DataAccess.EF.Repositories.Todo
{
    public class DeleteTodoByIdRepository : IDeleteTodoByIdRepository
    {
        private readonly ApplicationContext _dbContext;

        public DeleteTodoByIdRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Delete(Guid id, CancellationToken token)
        {
            await _dbContext.Todos
                .Where(todo => todo.Id == id)
                .ExecuteDeleteAsync(token);
        }
    }
}