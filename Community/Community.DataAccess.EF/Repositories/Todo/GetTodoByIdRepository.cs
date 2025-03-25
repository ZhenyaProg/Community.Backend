using Community.Core.Models;
using Community.Core.Repositories.Todo;
using Community.DataAccess.EF.Entities;

namespace Community.DataAccess.EF.Repositories.Todo
{
    public class GetTodoByIdRepository : IGetTodoByIdRepository
    {
        private readonly ApplicationContext _dbContext;

        public GetTodoByIdRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TodoModel> GetById(Guid id, CancellationToken token)
        {
            TodoEntity entity = await _dbContext.Todos.FindAsync(id, token);
            
            return new TodoModel
            {
                Id = entity.Id,
                Title = entity.Title,
                Success = entity.Success,
                Deadline = entity.Deadline,
                Description = entity.Description,
            };
        }
    }
}