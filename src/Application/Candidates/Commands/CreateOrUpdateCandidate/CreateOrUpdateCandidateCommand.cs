using CandidateManagementSystem.Application.Common.Models;
using CandidateManagementSystem.Domain.Entities.Candidates;

namespace CandidateManagementSystem.Application.Candidates.Commands.CreateOrUpdateCandidate;

/// <summary>
/// Represents a command to create or update a candidate.
/// </summary>
public record CreateOrUpdateCandidateCommand : IRequest<Result>
{
    public string FirstName { get; init; } = default!;
    public string LastName { get; init; } = default!;
    public string? PhoneNumber { get; init; }
    public string Email { get; init; } = default!;
    public TimeSlot? CallTimeInterval { get; init; }
    public string? LinkedInUrl { get; init; }
    public string? GitHubUrl { get; init; }
    public string Comment { get; init; } = default!;
}
