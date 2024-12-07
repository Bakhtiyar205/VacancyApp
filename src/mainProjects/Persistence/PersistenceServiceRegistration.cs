using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;

namespace Persistence;
public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        //services.AddScoped<IUnitOfWork, UnitOfWork>();
        //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        //services.AddScoped<IPersonRepository, PersonRepository>();
        //services.AddScoped<IVacancyRepository, VacancyRepository>();
        //services.AddScoped<IPersonVacancyRepository, PersonVacancyRepository>();
        //services.AddScoped<IExamRequirmentRepository, ExamRequirmentRepository>();
        return services;
    }
}
