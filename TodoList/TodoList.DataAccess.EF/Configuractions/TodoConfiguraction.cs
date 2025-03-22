using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.DataAccess.EF.Entities;

namespace TodoList.DataAccess.EF.Configuractions
{
    public class TodoConfiguraction : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder
                .ToTable("Todos")
                .HasKey(todo => todo.Id);
        }
    }
}