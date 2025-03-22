using Microsoft.EntityFrameworkCore;
using TodoList.DataAccess.EF.Configuractions;
using TodoList.DataAccess.EF.Entities;

namespace TodoList.DataAccess.EF
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }

        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoConfiguraction());
            base.OnModelCreating(modelBuilder);
        }
    }
}