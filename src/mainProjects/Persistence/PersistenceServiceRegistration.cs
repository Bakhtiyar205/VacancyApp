using Application.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;

namespace Persistence;
public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IExamRequirementRepository, ExamRequirementRepository>();
        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<IPersonQuestionRepository, PersonQuestionRepository>();
        services.AddScoped<IPersonVacancyRepository, PersonVacancyRepository>();
        services.AddScoped<IQuestionRepository, QuestionRepository>();
        services.AddScoped<IQuestionOptionRepository, QuestionOptionRepository>();
        services.AddScoped<IVacancyRepository, VacancyRepository>();

        return services;
    }
}
