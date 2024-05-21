using CandidateManagementSystem.Domain.Entities.Candidates;

namespace CandidateManagementSystem.Domain.Events;

public class CandidateUpdatedEvent : BaseEvent
{
    public Candidate Candidate { get; set; }
    public CandidateUpdatedEvent(Candidate candidate)
    {
        Candidate = candidate;
    }
}
