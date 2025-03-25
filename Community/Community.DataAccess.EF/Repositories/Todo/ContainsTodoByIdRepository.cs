using Community.Core.Repositories.Todo;
using Microsoft.EntityFrameworkCore;

namespace Community.DataAccess.EF.Repositories.Todo
{
    public class ContainsTodoByIdRepository : IContainsTodoByIdRepository
    {
        private readonly ApplicationContext _dbContext;

        public ContainsTodoByIdRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Contains(Guid id)
        {
            return await _dbContext.Todos.AnyAsync(todo => todo.Id == id);
        }
    }
}