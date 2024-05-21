namespace CandidateManagementSystem.Domain.Entities.Candidates;

public interface ICandidateRepository
{
    Task<Candidate?> GetByEmailAsync(string email);
    void Add(Candidate candidate);
    void Update(Candidate candidate);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
    
    Task<List<Candidate>> GetListAsync(CancellationToken cancellationToken = default);
}
