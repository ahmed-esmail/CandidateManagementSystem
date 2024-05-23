using CandidateManagementSystem.Application.Candidates.Commands.CreateOrUpdateCandidate;
using CandidateManagementSystem.Application.Candidates.Queries.GetCandidatesWithPagination;
using CandidateManagementSystem.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace CandidateManagementSystem.Web.Endpoints;

public class Candidates : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetCandidates)
            .MapPost(CreateOrUpdateCandidate);
    }
    
    /// <summary>
    /// Retrieves a list of candidates.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<PaginatedList<CandidateDto>> GetCandidates(ISender sender,
        [AsParameters] GetCandidatesWithPaginationQuery query,
        CancellationToken cancellationToken)
    {
        return sender.Send(query, cancellationToken);
    }

    /// <summary>
    /// Creates or updates a candidate.
    /// </summary>
    /// <param name="sender">The sender object.</param>
    /// <param name="command">The create or update candidate command.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A result indicating whether the operation was successful.</returns>
    [HttpPost("CreateOrUpdateCandidate")]
    public async Task<Result> CreateOrUpdateCandidate(ISender sender,
        [FromBody] CreateOrUpdateCandidateCommand command,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(command, cancellationToken);
        return result.Succeeded ? Result.Success() : Result.Failure(result.Errors);
    }
}
