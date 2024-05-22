using CandidateManagementSystem.Domain.Events;
using Microsoft.Extensions.Logging;

namespace CandidateManagementSystem.Application.EventHandlers;

public class CandidateCreatedEventHandler
{
    private readonly ILogger<CandidateCreatedEventHandler> _logger;

    public CandidateCreatedEventHandler(ILogger<CandidateCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(CandidateCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("TestTask Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
