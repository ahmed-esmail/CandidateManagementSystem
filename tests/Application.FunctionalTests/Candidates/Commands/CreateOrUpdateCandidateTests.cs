using CandidateManagementSystem.Application.Candidates.Commands.CreateOrUpdateCandidate;
using CandidateManagementSystem.Application.Common.Exceptions;
using CandidateManagementSystem.Domain.Entities.Candidates;

namespace CandidateManagementSystem.Application.FunctionalTests.Candidates.Commands;

using static Testing;

public class CreateOrUpdateCandidateTests : BaseTestFixture
{
    [Test]
    public async Task ShouldCreateCandidate()
    {
        var userId = await RunAsDefaultUserAsync();

        var command = new CreateOrUpdateCandidateCommand
        {
            Email = "new@example.com",
            FirstName = "John",
            LastName = "Doe",
            PhoneNumber = "1234567890",
            LinkedInUrl = "https://linkedin.com/in/johndoe",
            GitHubUrl = "https://github.com/johndoe",
            Comment = "New candidate"
        };

        var result = await SendAsync(command);

        var candidate = await GetCandidateByEmailAsync(command.Email);

        candidate.Should().NotBeNull();
        candidate!.FirstName.Should().Be(command.FirstName);
        candidate.LastName.Should().Be(command.LastName);
        candidate.PhoneNumber.Should().Be(command.PhoneNumber);
        candidate.LinkedInProfileUrl.Should().Be(command.LinkedInUrl);
        candidate.GitHubProfileUrl.Should().Be(command.GitHubUrl);
        candidate.Comment.Should().Be(command.Comment);
    }

    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateOrUpdateCandidateCommand();
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldUpdateExistingCandidate()
    {
        var candidate = Candidate.CreateCandidateWithBasicInfo(
            email: "existing@example.com",
            firstName: "John",
            lastName: "Doe",
            comment: "Existing candidate"
        );
        
        await AddAsync(candidate);

        var command = new CreateOrUpdateCandidateCommand
        {
            Email = "existing@example.com",
            FirstName = "Jane",
            LastName = "Smith",
            PhoneNumber = "0987654321",
            LinkedInUrl = "https://linkedin.com/in/janesmith",
            GitHubUrl = "https://github.com/janesmith",
            Comment = "Updated candidate"
        };

        await SendAsync(command);

        var updatedCandidate = await GetCandidateByEmailAsync(command.Email);

        updatedCandidate.Should().NotBeNull();
        updatedCandidate!.FirstName.Should().Be(command.FirstName);
        updatedCandidate.LastName.Should().Be(command.LastName);
        updatedCandidate.PhoneNumber.Should().Be(command.PhoneNumber);
        updatedCandidate.LinkedInProfileUrl.Should().Be(command.LinkedInUrl);
        updatedCandidate.GitHubProfileUrl.Should().Be(command.GitHubUrl);
        updatedCandidate.Comment.Should().Be(command.Comment);
    }
    
    [Test]
    public async Task ShouldNotCreateCandidateWithInvalidLinkedInUrl()
    {
        var command = new CreateOrUpdateCandidateCommand
        {
            Email = "invalidlinkedin@example.com",
            FirstName = "John",
            LastName = "Doe",
            LinkedInUrl = "invalid-url",
            Comment = "Invalid LinkedIn URL"
        };

        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldNotCreateCandidateWithInvalidGitHubUrl()
    {
        var command = new CreateOrUpdateCandidateCommand
        {
            Email = "invalidgithub@example.com",
            FirstName = "John",
            LastName = "Doe",
            GitHubUrl = "invalid-url",
            Comment = "Invalid GitHub URL"
        };

        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }
    
    [Test]
    public async Task ShouldNotCreateCandidateWithPhoneNumberExceedingMaxLength()
    {
        var command = new CreateOrUpdateCandidateCommand
        {
            Email = "longphone@example.com",
            FirstName = "John",
            LastName = "Doe",
            PhoneNumber = new string('1', 21), // Exceeds max length
            Comment = "Phone number too long"
        };

        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }
    

    [Test]
    public async Task ShouldNotUpdateCandidateWithInvalidData()
    {
        var candidate = Candidate.CreateCandidate(
            email: "updatable@example.com",
            firstName: "John",
            lastName: "Doe",
            phoneNumber: null,
            bestTimeToCall: null,
            linkedInProfileUrl: null,
            gitHubProfileUrl: null,
            comment: "Updatable candidate"
        );
        await AddAsync(candidate);

        var command = new CreateOrUpdateCandidateCommand
        {
            Email = "updatable@example.com",
            FirstName = "",
            LastName = "",
            PhoneNumber = null,
            LinkedInUrl = "invalid-url",
            GitHubUrl = "invalid-url",
            Comment = "Updated candidate with invalid data"
        };

        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldNotCreateCandidateWithEmptyComment()
    {
        var command = new CreateOrUpdateCandidateCommand
        {
            Email = "emptycomment@example.com",
            FirstName = "John",
            LastName = "Doe",
            Comment = "" // Empty comment
        };

        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldNotUpdateCandidateWithEmptyEmail()
    {
        var candidate = Candidate.CreateCandidate(
            email: "updateemail@example.com",
            firstName: "John",
            lastName: "Doe",
            phoneNumber: "1234567890",
            bestTimeToCall: null,
            linkedInProfileUrl: null,
            gitHubProfileUrl: null,
            comment: "Existing candidate"
        );
        await AddAsync(candidate);

        var command = new CreateOrUpdateCandidateCommand
        {
            Email = "", // Empty email
            FirstName = "Jane",
            LastName = "Smith",
            PhoneNumber = "0987654321",
            LinkedInUrl = "https://linkedin.com/in/janesmith",
            GitHubUrl = "https://github.com/janesmith",
            Comment = "Updated candidate"
        };

        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }
    
}
