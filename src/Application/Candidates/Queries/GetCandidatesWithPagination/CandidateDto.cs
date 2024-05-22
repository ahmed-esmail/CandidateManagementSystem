using CandidateManagementSystem.Domain.Entities.Candidates;

namespace CandidateManagementSystem.Application.Candidates.Queries.GetCandidatesWithPagination;

public class CandidateDto
{
    public string Email { get; } = null!;
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string? PhoneNumber { get; private set; }
    public TimeSlot? BestTimeToCall { get; private set; }
    public string? LinkedInProfileUrl { get; private set; }
    public string? GitHubProfileUrl { get; private set; }
    public string Comment { get; private set; } = null!;
    
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Candidate, CandidateDto>();
        }
    }
}
