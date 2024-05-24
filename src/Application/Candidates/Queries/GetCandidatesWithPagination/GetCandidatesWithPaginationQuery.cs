using CandidateManagementSystem.Application.Common.Interfaces;
using CandidateManagementSystem.Application.Common.Mappings;
using CandidateManagementSystem.Application.Common.Models;

namespace CandidateManagementSystem.Application.Candidates.Queries.GetCandidatesWithPagination;

public record GetCandidatesWithPaginationQuery : IRequest<PaginatedList<CandidateDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
};

/// <summary>
/// Handles the GetCandidatesQuery request.
/// </summary>
public class GetCandidatesQueryWithPaginationHandler : IRequestHandler<GetCandidatesWithPaginationQuery, PaginatedList<CandidateDto>>
{
    private readonly ICandidateRepository _repository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the GetCandidatesQueryHandler class.
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="repository"></param>
    public GetCandidatesQueryWithPaginationHandler(IMapper mapper, ICandidateRepository repository)
    {
        this._mapper = mapper;
        _repository = repository;
    }

    /// <summary>
    /// Handles the GetCandidatesQuery request.
    /// </summary>
    /// <param name="request">The GetCandidatesQuery request.</param>
    /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a List of Candidate.</returns>
    public Task<PaginatedList<CandidateDto>> Handle(GetCandidatesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return _repository.GetListAsyncWithPagination(request, cancellationToken);
    }
}
