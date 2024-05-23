using CandidateManagementSystem.Domain.Entities.Candidates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CandidateManagementSystem.Infrastructure.Data.Configurations;

public class CandidateConfiguration  : IEntityTypeConfiguration<Candidate>
{
    public void Configure(EntityTypeBuilder<Candidate> builder)
    {
        builder.Property(t => t.FirstName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(t => t.LastName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(t => t.Email)
            .HasMaxLength(200)
            .IsRequired();
        
        builder.HasIndex(t => t.Email)
            .IsUnique();
        
        builder.Property(t => t.PhoneNumber)
            .HasMaxLength(200);

        builder.Property(t => t.LinkedInProfileUrl)
            .HasMaxLength(200);

        builder.Property(t => t.GitHubProfileUrl)
            .HasMaxLength(200);

        builder.Property(t => t.Comment)
            .HasMaxLength(200);

        builder.OwnsOne(t => t.BestTimeToCall, interval =>
        {
            interval.Property(i => i.StartTime)
                .IsRequired();

            interval.Property(i => i.EndTime)
                .IsRequired();

            interval.Property(i => i.Date)
                .IsRequired();
        });
    }
}
