using CandidateManagementSystem.Domain.Entities.Candidates;
using NUnit.Framework;

namespace CandidateManagementSystem.Domain.UnitTests.Candidates
{
    [TestFixture]
    public class CandidateTests
    {
        [Test]
        public void CreateCandidate_ShouldInitializePropertiesCorrectly()
        {
            // Arrange
            string email = "test@example.com";
            string firstName = "John";
            string lastName = "Doe";
            string phoneNumber = "123-456-7890";
            TimeSlot? bestTimeToCall = null; // Assume TimeSlot is a valid object
            string linkedInProfileUrl = "https://linkedin.com/in/johndoe";
            string gitHubProfileUrl = "https://github.com/johndoe";
            string comment = "This is a comment";

            // Act
            var candidate = Candidate.CreateCandidate(
                email,
                firstName,
                lastName,
                phoneNumber,
                bestTimeToCall,
                linkedInProfileUrl,
                gitHubProfileUrl,
                comment);

            // Assert
            Assert.That(candidate.Email, Is.EqualTo(email));
            Assert.That(candidate.FirstName, Is.EqualTo(firstName));
            Assert.That(candidate.LastName, Is.EqualTo(lastName));
            Assert.That(candidate.PhoneNumber, Is.EqualTo(phoneNumber));
            Assert.That(candidate.BestTimeToCall, Is.EqualTo(bestTimeToCall));
            Assert.That(candidate.LinkedInProfileUrl, Is.EqualTo(linkedInProfileUrl));
            Assert.That(candidate.GitHubProfileUrl, Is.EqualTo(gitHubProfileUrl));
            Assert.That(candidate.Comment, Is.EqualTo(comment));
        }

        [Test]
        public void UpdateContactInformation_ShouldUpdatePropertiesCorrectly()
        {
            // Arrange
            var candidate = Candidate.CreateCandidate(
                "test@example.com",
                "John",
                "Doe",
                "123-456-7890",
                null,
                "https://linkedin.com/in/johndoe",
                "https://github.com/johndoe",
                "This is a comment");

            string newFirstName = "Jane";
            string newLastName = "Smith";
            string newPhoneNumber = "098-765-4321";
            TimeSlot? newBestTimeToCall = null; // Assume TimeSlot is a valid object
            string newLinkedInProfileUrl = "https://linkedin.com/in/janesmith";
            string newGitHubProfileUrl = "https://github.com/janesmith";
            string newComment = "Updated comment";

            // Act
            candidate.UpdateContactInformation(
                newFirstName,
                newLastName,
                newPhoneNumber,
                newBestTimeToCall,
                newLinkedInProfileUrl,
                newGitHubProfileUrl,
                newComment);

            // Assert
            Assert.That(candidate.FirstName, Is.EqualTo(newFirstName));
            Assert.That(candidate.LastName, Is.EqualTo(newLastName));
            Assert.That(candidate.PhoneNumber, Is.EqualTo(newPhoneNumber));
            Assert.That(candidate.BestTimeToCall, Is.EqualTo(newBestTimeToCall));
            Assert.That(candidate.LinkedInProfileUrl, Is.EqualTo(newLinkedInProfileUrl));
            Assert.That(candidate.GitHubProfileUrl, Is.EqualTo(newGitHubProfileUrl));
            Assert.That(candidate.Comment, Is.EqualTo(newComment));
        }

        [Test]
        public void Equals_ShouldReturnTrueForSameEmail()
        {
            // Arrange
            var candidate1 = Candidate.CreateCandidate(
                "test@example.com",
                "John",
                "Doe",
                "123-456-7890",
                null,
                "https://linkedin.com/in/johndoe",
                "https://github.com/johndoe",
                "This is a comment");

            var candidate2 = Candidate.CreateCandidate(
                "test@example.com",
                "Jane",
                "Smith",
                "098-765-4321",
                null,
                "https://linkedin.com/in/janesmith",
                "https://github.com/janesmith",
                "Another comment");

            // Act
            bool result = candidate1.Equals(candidate2);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void Equals_ShouldReturnFalseForDifferentEmails()
        {
            // Arrange
            var candidate1 = Candidate.CreateCandidate(
                "test1@example.com",
                "John",
                "Doe",
                "123-456-7890",
                null,
                "https://linkedin.com/in/johndoe",
                "https://github.com/johndoe",
                "This is a comment");

            var candidate2 = Candidate.CreateCandidate(
                "test2@example.com",
                "Jane",
                "Smith",
                "098-765-4321",
                null,
                "https://linkedin.com/in/janesmith",
                "https://github.com/janesmith",
                "Another comment");

            // Act
            bool result = candidate1.Equals(candidate2);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void GetHashCode_ShouldReturnEmailHashCode()
        {
            // Arrange
            string email = "test@example.com";
            var candidate = Candidate.CreateCandidate(
                email,
                "John",
                "Doe",
                "123-456-7890",
                null,
                "https://linkedin.com/in/johndoe",
                "https://github.com/johndoe",
                "This is a comment");

            // Act
            int hashCode = candidate.GetHashCode();

            // Assert
            Assert.That(hashCode, Is.EqualTo(email.GetHashCode()));
        }
    }
}
