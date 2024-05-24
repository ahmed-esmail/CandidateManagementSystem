using CandidateManagementSystem.Domain.Entities.Candidates;

namespace CandidateManagementSystem.Application.Candidates.Queries.GetCandidatesWithPagination;

public class CandidateDto
{
    public string Email { get; init; } = null!;
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public string? PhoneNumber { get; init; }
    public TimeSlot? BestTimeToCall { get; init; }
    public string? LinkedInProfileUrl { get; init; }
    public string? GitHubProfileUrl { get; init; }
    public string Comment { get; init; } = null!;
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Candidate, CandidateDto>();
        }
    }
}
