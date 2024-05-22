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
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the GetCandidatesQueryHandler class.
    /// </summary>
    /// <param name="context">An instance of ICandidateRepository to interact with the candidates data.</param>
    /// <param name="mapper"></param>
    public GetCandidatesQueryWithPaginationHandler(IApplicationDbContext context, IMapper mapper)
    {
        this._context = context;
        this._mapper = mapper;
    }

    /// <summary>
    /// Handles the GetCandidatesQuery request.
    /// </summary>
    /// <param name="request">The GetCandidatesQuery request.</param>
    /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a List of Candidate.</returns>
    public Task<PaginatedList<CandidateDto>> Handle(GetCandidatesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return _context.Candidates.ProjectTo<CandidateDto>(_mapper.ConfigurationProvider)
                                   .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
