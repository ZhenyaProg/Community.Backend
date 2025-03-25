using Community.Core.Models;
using Community.Core.Repositories.Todo;
using Microsoft.EntityFrameworkCore;

namespace Community.DataAccess.EF.Repositories.Todo
{
    public class GetTodoByPageRepository : IGetTodoByPageRepository
    {
        private readonly ApplicationContext _dbContext;

        public GetTodoByPageRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TodoModel>> GetTodos(int page, int pageSize, CancellationToken token)
        {
            TodoModel[] models = await _dbContext.Todos
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(entity => new TodoModel
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    Success = entity.Success,
                    Deadline = entity.Deadline,
                    Description = entity.Description,
                })
                .ToArrayAsync(token);

            return models;
        }
    }
}