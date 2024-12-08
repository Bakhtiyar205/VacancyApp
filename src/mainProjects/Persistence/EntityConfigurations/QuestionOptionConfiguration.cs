using Application.Services.DateTimeProviders;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;
internal class QuestionOptionConfiguration : IEntityTypeConfiguration<QuestionOption>
{

    public void Configure(EntityTypeBuilder<QuestionOption> builder)
    {
        builder.HasKey(builder => builder.Id);

        builder.Property(builder => builder.Option)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(builder => builder.IsDeleted)
            .HasDefaultValue(false);

        builder.HasOne(builder => builder.Question)
            .WithMany(builder => builder.QuestionOptions)
            .HasForeignKey(builder => builder.QuestionId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
