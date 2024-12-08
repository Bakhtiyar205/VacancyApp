using Application.Services.DateTimeProviders;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;
internal class VacancyConfiguration : IEntityTypeConfiguration<Vacancy>
{

    public void Configure(EntityTypeBuilder<Vacancy> builder)
    {
        builder.HasKey(builder => builder.Id);

        builder.Property(builder => builder.Title)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(builder => builder.Description)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(builder => builder.IsDeleted)
            .HasDefaultValue(false);

        builder.HasMany(builder => builder.PersonVacancies)
            .WithOne(builder => builder.Vacancy)
            .HasForeignKey(builder => builder.VacancyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(builder => builder.Questions)
            .WithOne(builder => builder.Vacancy)
            .HasForeignKey(builder => builder.VacancyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
