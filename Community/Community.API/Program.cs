using Community.API.Middlewares;
using Community.Application.DI;
using Community.DataAccess.DI;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        string? connectionString = builder.Configuration.GetConnectionString("ApplicationContext");
        builder.Services.AddRepositories(connectionString)
                        .AddUseCases();

        builder.Services.AddControllers();

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.WithOrigins("http://127.0.0.1:5500");
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
            });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseCors();
        app.UseHttpsRedirection();

        app.MapControllers();

        app.UseMiddleware<ErrorHandlingMiddleware>();

        app.Run();
    }
}