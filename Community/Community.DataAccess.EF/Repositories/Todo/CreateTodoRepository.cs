using Community.Core.Repositories.Todo;
using Community.DataAccess.EF.Entities;

namespace Community.DataAccess.EF.Repositories.Todo
{
    public class CreateTodoRepository : ICreateTodoRepository
    {
        private readonly ApplicationContext _dbContext;

        public CreateTodoRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(string title, bool success, DateTime deadline, string description, CancellationToken token)
        {
            TodoEntity entity = new TodoEntity
            {
                Id = Guid.NewGuid(),
                Title = title,
                Description = description,
                Deadline = deadline,
                Success = success,
            };

            await _dbContext.Todos.AddAsync(entity, token);
            await _dbContext.SaveChangesAsync(token);
        }
    }
}