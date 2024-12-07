using Application.Services.DateTimeProviders;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;
internal class ExamRequirementConfiguration : IEntityTypeConfiguration<ExamRequirement>
{

    public void Configure(EntityTypeBuilder<ExamRequirement> builder)
    {
        builder.HasKey(builder => builder.Id);

        builder.Property(builder => builder.Detail)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(builder => builder.CreatedDate)
            .HasDefaultValue(IDateTimeProvider.Now);

        builder.Property(builder => builder.IsDeleted)
            .HasDefaultValue(false);
    }
}
