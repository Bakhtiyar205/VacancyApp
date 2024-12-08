using Application.Services.DateTimeProviders;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;
internal class PersonVacancyConfiguration : IEntityTypeConfiguration<PersonVacancy>
{
    //private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;
    public void Configure(EntityTypeBuilder<PersonVacancy> builder)
    {
        builder.HasKey(builder => builder.Id);

        builder.HasOne(builder => builder.Person)
            .WithMany(builder => builder.PersonVacancies)
            .HasForeignKey(builder => builder.PersonId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(builder => builder.Vacancy)
            .WithMany(builder => builder.PersonVacancies)
            .HasForeignKey(builder => builder.VacancyId)
            .OnDelete(DeleteBehavior.ClientSetNull);

    }
}
