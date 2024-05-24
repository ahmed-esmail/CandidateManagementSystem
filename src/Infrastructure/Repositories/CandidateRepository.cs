using AutoMapper;
using AutoMapper.QueryableExtensions;
using CandidateManagementSystem.Application.Candidates;
using CandidateManagementSystem.Application.Candidates.Queries.GetCandidatesWithPagination;
using CandidateManagementSystem.Application.Common.Interfaces;
using CandidateManagementSystem.Application.Common.Mappings;
using CandidateManagementSystem.Application.Common.Models;
using CandidateManagementSystem.Domain.Entities.Candidates;
using Microsoft.EntityFrameworkCore;

namespace CandidateManagementSystem.Infrastructure.Repositories;

/// <summary>
/// Repository for managing Candidate entities in the database.
/// </summary>
public class CandidateRepository : ICandidateRepository
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the CandidateRepository class.
    /// </summary>
    /// <param name="context">The application's database context.</param>
    /// <param name="mapper"></param>
    public CandidateRepository(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Retrieves a candidate by their email.
    /// </summary>
    /// <param name="email">The email of the candidate to retrieve.</param>
    /// <returns>The candidate with the specified email, or null if no such candidate exists.</returns>
    public async Task<Candidate?> GetByEmailAsync(string email)
    {
        return await _context.Candidates
            .Where(x => x.Email.ToLower() == email.ToLower())
            .SingleOrDefaultAsync();
    }

    /// <summary>
    /// Adds a new candidate to the database.
    /// </summary>
    /// <param name="candidate">The candidate to add.</param>
    public void Add(Candidate candidate)
    {
        _context.Candidates.Add(candidate);
    }

    /// <summary>
    /// Updates an existing candidate in the database.
    /// </summary>
    /// <param name="candidate">The candidate to update.</param>
    public void Update(Candidate candidate)
    {
        _context.Candidates.Update(candidate);
    }

    /// <summary>
    /// Saves any changes made in the context to the database.
    /// </summary>
    /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<PaginatedList<CandidateDto>> GetListAsyncWithPagination(GetCandidatesWithPaginationQuery request,
        CancellationToken cancellationToken = default)
    {
        return await _context.Candidates
            .ProjectTo<CandidateDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
    
}
