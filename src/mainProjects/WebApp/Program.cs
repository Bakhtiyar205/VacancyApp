using Application;
using Persistence;
using Microsoft.Extensions.Configuration;
namespace WebApp;



public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var configuration = builder.Configuration;
        var services = builder.Services;

        // Add services to the container.

        services.AddControllers();

        services.AddApplicationServices(builder.Configuration);
        services.AddPersistenceServices(configuration);


        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
