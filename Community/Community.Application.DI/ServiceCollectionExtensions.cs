using Community.Application.UseCases.Todo;
using Community.Application.Validators.Todo;
using Community.Core.UseCases.Todo;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Community.Application.DI
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<ICreateTodoUseCase, CreateTodoUseCase>();
            services.AddScoped<IGetTodoByPageUseCase, GetTodoByPageUseCase>();
            services.AddScoped<IGetTodoByIdUseCase, GetTodoByIdUseCase>();
            services.AddScoped<IEditTodoUseCase, EditTodoByIdUseCase>();
            services.AddScoped<IDeleteTodoByIdUseCase, DeleteTodoByIdUseCase>();

            services.AddValidatorsFromAssemblyContaining<CreateTodoCommandValidator>();

            return services;
        }
    }
}