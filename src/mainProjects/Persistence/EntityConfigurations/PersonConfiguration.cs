using Application.Services.DateTimeProviders;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;
internal class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    //private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;

    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(builder => builder.Id);

        builder.Property(builder => builder.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(builder => builder.Surname)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(builder => builder.Email)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(builder => builder.PhoneNumber)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(builder => builder.ExamRequirmentAgreement)
            .HasDefaultValue(false);

        builder.Property(builder => builder.IsParticipated)
            .HasDefaultValue(false);

        builder.Property(builder => builder.IsDeleted)
            .HasDefaultValue(false);

        builder.HasMany(builder => builder.PersonVacancies)
            .WithOne(builder => builder.Person)
            .HasForeignKey(builder => builder.PersonId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(builder => builder.PersonQuestions)
            .WithOne(builder => builder.Person)
            .HasForeignKey(builder => builder.PersonId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
