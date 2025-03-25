using Microsoft.EntityFrameworkCore;
using Community.DataAccess.EF.Configuractions;
using Community.DataAccess.EF.Entities;

namespace Community.DataAccess.EF
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }

        public DbSet<TodoEntity> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoConfiguraction());
            base.OnModelCreating(modelBuilder);
        }
    }
}