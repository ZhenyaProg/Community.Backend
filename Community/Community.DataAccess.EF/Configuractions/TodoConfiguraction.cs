using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Community.DataAccess.EF.Entities;

namespace Community.DataAccess.EF.Configuractions
{
    public class TodoConfiguraction : IEntityTypeConfiguration<TodoEntity>
    {
        public void Configure(EntityTypeBuilder<TodoEntity> builder)
        {
            builder
                .ToTable("Todos")
                .HasKey(todo => todo.Id);
        }
    }
}