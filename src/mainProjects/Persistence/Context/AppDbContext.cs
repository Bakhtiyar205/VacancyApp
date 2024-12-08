using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context.Interceptors;

namespace Persistence.Context;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<ExamRequirement> ExamRequirments { get; set; } = default!;
    public DbSet<Person> Persons { get; set; } = default!;
    public DbSet<PersonQuestion> PeopleQuestions { get; set; } = default!;
    public DbSet<PersonVacancy> PeopleVacancies { get; set; } = default!;
    public DbSet<Question> Questions { get; set; } = default!;
    public DbSet<QuestionOption> QuestionOptions { get; set; } = default!;
    public DbSet<Vacancy> Vacancies { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new AuditSaveChangesInterceptor());

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
