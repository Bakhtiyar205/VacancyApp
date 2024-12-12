using Application.Services.DateTimeProviders;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;
internal class PersonQuestionConfiguration : IEntityTypeConfiguration<PersonQuestion>
{
    //private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;

    public void Configure(EntityTypeBuilder<PersonQuestion> builder)
    {
        builder.HasKey(builder => builder.Id);

        builder.HasOne(builder => builder.Vacancy)
            .WithMany(builder => builder.PersonQuestions)
            .HasForeignKey(builder => builder.VacancyId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(builder => builder.Person)
            .WithMany(builder => builder.PersonQuestions)
            .HasForeignKey(builder => builder.PersonId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasOne(builder => builder.Question)
            .WithMany(builder => builder.PersonQuestions)
            .HasForeignKey(builder => builder.QuestionId)
            .OnDelete(DeleteBehavior.ClientSetNull);

    }
}
