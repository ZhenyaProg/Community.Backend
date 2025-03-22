using Microsoft.EntityFrameworkCore;
using TodoList.DataAccess.EF;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        string? connectionString = builder.Configuration.GetConnectionString(nameof(ApplicationContext));
        builder.Services
            .AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));

        builder.Services.AddControllers();

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }
}