using CandidateManagementSystem.Application.Common.Interfaces;

namespace CandidateManagementSystem.Application.Candidates.Commands.CreateOrUpdateCandidate;

public class CreateOrUpdateCandidateCommandValidator : AbstractValidator<CreateOrUpdateCandidateCommand>
{
    private readonly IApplicationDbContext _context;
    public CreateOrUpdateCandidateCommandValidator(IApplicationDbContext context)
    {
        _context = context;
        
        RuleFor(v => v.FirstName)
            .MaximumLength(200)
            .NotEmpty();
        
        RuleFor(v => v.LastName)
            .MaximumLength(200)
            .NotEmpty();

        RuleFor(v => v.Email)
            .NotEmpty().WithMessage("'Email' must not be empty.")
            .MaximumLength(200).WithMessage("Email must be less than 200 characters.")
            .EmailAddress().WithMessage("Invalid email address format.");
            
        
        RuleFor(v => v.LinkedInUrl)
            .MaximumLength(200).WithMessage("LinkedIn URL must be less than 200 characters")
            .Must(BeValidUrl).When(v => !string.IsNullOrEmpty(v.LinkedInUrl)).WithMessage("LinkedIn URL must be a valid URL.");
        
        RuleFor(v => v.GitHubUrl)
            .MaximumLength(200)
            .WithMessage("GitHub URL must be less than 200 characters")
            .Must(BeValidUrl).When(v => !string.IsNullOrEmpty(v.GitHubUrl)).WithMessage("GitHub URL must be a valid URL.");
        
        RuleFor(v => v.Comment)
            .MaximumLength(2000)
            .NotEmpty()
            .WithMessage("Comment must be less than 2000 characters");
        
        RuleFor(v => v.PhoneNumber)
            .MaximumLength(20)
            .WithMessage("Phone number must be less than 20 characters");
    }
    
    private static bool BeValidUrl(string url)
    {
        return Uri.IsWellFormedUriString(url, UriKind.Absolute);
    }
    
}
