using CandidateManagementSystem.Domain.Events;
using Microsoft.Extensions.Logging;

namespace CandidateManagementSystem.Application.EventHandlers;

public class CandidateUpdateEventHandler
{
    private readonly ILogger<CandidateUpdateEventHandler> _logger;

    public CandidateUpdateEventHandler(ILogger<CandidateUpdateEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(CandidateCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation(" Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
