using CandidateManagementSystem.Domain.Entities.Candidates;

namespace CandidateManagementSystem.Domain.Events;

public class CandidateCreatedEvent : BaseEvent
{
    public CandidateCreatedEvent(Candidate item)
    {
        Candidate = item;
    }

    public Candidate Candidate { get; }
}
