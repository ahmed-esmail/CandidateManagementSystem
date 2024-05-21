namespace CandidateManagementSystem.Domain.Entities.Candidates;

public class Candidate : BaseAuditableEntity
{
    public string Email { get; } = null!;
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string? PhoneNumber { get; private set; }
    public TimeSlot? BestTimeToCall { get; private set; }
    public string? LinkedInProfileUrl { get; private set; }
    public string? GitHubProfileUrl { get; private set; }
    public string Comment { get; private set; } = null!;
    
    public Candidate()
    {

    }
    private Candidate(string email,
        string firstName,
        string lastName,
        string? phoneNumber,
        TimeSlot? bestTimeToCall,
        string? linkedInProfileUrl,
        string? gitHubProfileUrl,
        string comment)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        BestTimeToCall = bestTimeToCall;
        LinkedInProfileUrl = linkedInProfileUrl;
        GitHubProfileUrl = gitHubProfileUrl;
        Comment = comment;
    }

    private Candidate(string email, string firstName, string lastName, string comment)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        Comment = comment;
    }

    public static Candidate CreateCandidateWithBasicInfo(string email,
        string firstName,
        string lastName,
        string comment)
    {
        return new Candidate(email,
            firstName,
            lastName,
            comment);
    }
    
    public static Candidate CreateCandidate(string email,
        string firstName,
        string lastName,
        string? phoneNumber,
        TimeSlot? bestTimeToCall,
        string? linkedInProfileUrl,
        string? gitHubProfileUrl,
        string comment)
    {
        return new Candidate(email,
            firstName,
            lastName,
            phoneNumber,
            bestTimeToCall,
            linkedInProfileUrl,
            gitHubProfileUrl,
            comment);
    }


    public void UpdateContactInformation(string firstName,
        string lastName,
        string? phoneNumber,
        TimeSlot? bestTimeToCall,
        string? linkedInProfileUrl,
        string? gitHubProfileUrl,
        string comment)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        BestTimeToCall = bestTimeToCall;
        LinkedInProfileUrl = linkedInProfileUrl;
        GitHubProfileUrl = gitHubProfileUrl;
        Comment = comment;
    }

    public override bool Equals(object? obj)
    {
        return obj is Candidate other && Email == other.Email;
    }

    public override int GetHashCode()
    {
        return Email.GetHashCode();
    }
}
