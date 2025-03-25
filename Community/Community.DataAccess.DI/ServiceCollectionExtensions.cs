using Community.Core.Repositories.Todo;
using Community.DataAccess.EF;
using Community.DataAccess.EF.Repositories.Todo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Community.DataAccess.DI
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<ICreateTodoRepository, CreateTodoRepository>();
            services.AddScoped<IGetTodoByPageRepository, GetTodoByPageRepository>();
            services.AddScoped<IGetTodoByIdRepository, GetTodoByIdRepository>();
            services.AddScoped<IContainsTodoByIdRepository, ContainsTodoByIdRepository>();
            services.AddScoped<IEditTodoRepository, EditTodoRepository>();
            services.AddScoped<IDeleteTodoByIdRepository, DeleteTodoByIdRepository>();

            return services;
        }
    }
}