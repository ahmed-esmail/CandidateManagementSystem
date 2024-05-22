using CandidateManagementSystem.Application.Candidates.Queries.GetCandidatesWithPagination;
using CandidateManagementSystem.Domain.Entities;
using CandidateManagementSystem.Domain.Entities.Candidates;

namespace CandidateManagementSystem.Application.Common.Models;

public class LookupDto
{
    public int Email { get; init; }

    public string? FirstName { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Candidate, LookupDto>();
        }
    }
}
