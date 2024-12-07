using Application.Services.DateTimeProviders;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;
internal class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    //private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;

    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.HasKey(builder => builder.Id);

        builder.Property(builder => builder.QuestionDetail)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(builder => builder.OptionCount)
            .HasDefaultValue(3);

        builder.Property(builder => builder.CreatedDate)
            .HasDefaultValue(IDateTimeProvider.Now);

        builder.Property(builder => builder.IsDeleted)
            .HasDefaultValue(false);    

        builder.HasMany(builder => builder.QuestionOptions)
            .WithOne(builder => builder.Question)
            .HasForeignKey(builder => builder.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(builder => builder.PersonQuestions)
            .WithOne(builder => builder.Question)
            .HasForeignKey(builder => builder.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(builder => builder.Vacancy)
            .WithMany(builder => builder.Questions)
            .HasForeignKey(builder => builder.VacancyId)
            .OnDelete(DeleteBehavior.ClientSetNull);

    }
}
