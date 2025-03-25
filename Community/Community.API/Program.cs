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

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }
}