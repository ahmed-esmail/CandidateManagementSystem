using CandidateManagementSystem.Application.Common.Models;
using CandidateManagementSystem.Domain.Entities.Candidates;
using CandidateManagementSystem.Domain.Events;

namespace CandidateManagementSystem.Application.Candidates.Commands.CreateOrUpdateCandidate;

/// <summary>
/// Represents a command to create or update a candidate.
/// </summary>
public class CreateOrUpdateCandidateCommandHandler(ICandidateRepository repository)
    : IRequestHandler<CreateOrUpdateCandidateCommand, Result>
{
    public async Task<Result> Handle(CreateOrUpdateCandidateCommand request, CancellationToken cancellationToken)
    {
        var candidate = await repository.GetByEmailAsync(request.Email);

        if (candidate is null)
        {
            candidate = Candidate.CreateCandidate(request.Email,
                request.FirstName,
                request.LastName,
                request.PhoneNumber,
                request.CallTimeInterval,
                request.LinkedInUrl,
                request.GitHubUrl,
                request.Comment!);
            repository.Add(candidate);
            
            candidate.AddDomainEvent(new CandidateCreatedEvent(candidate));
        }
        else
        {
            candidate.UpdateContactInformation(request.FirstName,
                request.LastName,
                request.PhoneNumber,
                request.CallTimeInterval,
                request.LinkedInUrl,
                request.GitHubUrl,
                request.Comment);
            
            candidate.AddDomainEvent(new CandidateUpdatedEvent(candidate));
        }

        await repository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
