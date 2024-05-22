using CandidateManagementSystem.Domain.Entities;
using CandidateManagementSystem.Domain.Entities.Candidates;

namespace CandidateManagementSystem.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Candidate> Candidates { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
