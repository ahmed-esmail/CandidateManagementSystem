using CandidateManagementSystem.Application.Candidates.Queries.GetCandidatesWithPagination;
using CandidateManagementSystem.Application.Common.Models;
using CandidateManagementSystem.Domain.Entities.Candidates;

namespace CandidateManagementSystem.Application.Candidates;

public interface ICandidateRepository
{
    Task<Candidate?> GetByEmailAsync(string email);
    void Add(Candidate candidate);
    void Update(Candidate candidate);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<PaginatedList<CandidateDto>> GetListAsyncWithPagination(GetCandidatesWithPaginationQuery request,
        CancellationToken cancellationToken = default);
}
