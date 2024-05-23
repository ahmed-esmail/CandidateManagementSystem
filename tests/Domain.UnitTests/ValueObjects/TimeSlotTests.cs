using CandidateManagementSystem.Domain.Entities.Candidates;
using NUnit.Framework;

namespace CandidateManagementSystem.Domain.UnitTests.ValueObjects
{
    [TestFixture]
    public class TimeSlotTests
    {
        [Test]
        public void TimeSlot_ShouldInitializePropertiesCorrectly()
        {
            // Arrange
            var date = new DateTime(2024, 5, 19);
            var startTime = new TimeSpan(9, 0, 0);
            var endTime = new TimeSpan(17, 0, 0);

            // Act
            var timeSlot = new TimeSlot(date, startTime, endTime);

            // Assert
            Assert.That(timeSlot.Date, Is.EqualTo(date));
            Assert.That(timeSlot.StartTime, Is.EqualTo(startTime));
            Assert.That(timeSlot.EndTime, Is.EqualTo(endTime));
        }

        [Test]
        public void TimeSlot_ShouldThrowArgumentException_WhenStartTimeIsAfterEndTime()
        {
            // Arrange
            var date = new DateTime(2024, 5, 19);
            var startTime = new TimeSpan(17, 0, 0);
            var endTime = new TimeSpan(9, 0, 0);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new TimeSlot(date, startTime, endTime));
        }

        [Test]
        public void Equals_ShouldReturnTrueForSameDateAndTimes()
        {
            // Arrange
            var date = new DateTime(2024, 5, 19);
            var startTime = new TimeSpan(9, 0, 0);
            var endTime = new TimeSpan(17, 0, 0);

            var timeSlot1 = new TimeSlot(date, startTime, endTime);
            var timeSlot2 = new TimeSlot(date, startTime, endTime);

            // Act
            bool result = timeSlot1.Equals(timeSlot2);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void Equals_ShouldReturnFalseForDifferentDateOrTimes()
        {
            // Arrange
            var date1 = new DateTime(2024, 5, 19);
            var date2 = new DateTime(2024, 5, 20);
            var startTime1 = new TimeSpan(9, 0, 0);
            var startTime2 = new TimeSpan(10, 0, 0);
            var endTime1 = new TimeSpan(17, 0, 0);
            var endTime2 = new TimeSpan(18, 0, 0);

            var timeSlot1 = new TimeSlot(date1, startTime1, endTime1);
            var timeSlot2 = new TimeSlot(date2, startTime1, endTime1);
            var timeSlot3 = new TimeSlot(date1, startTime2, endTime1);
            var timeSlot4 = new TimeSlot(date1, startTime1, endTime2);

            // Act & Assert
            Assert.That(timeSlot1.Equals(timeSlot2), Is.False);
            Assert.That(timeSlot1.Equals(timeSlot3), Is.False);
            Assert.That(timeSlot1.Equals(timeSlot4), Is.False);
        }

        [Test]
        public void GetHashCode_ShouldReturnCombinedHashCode()
        {
            // Arrange
            var date = new DateTime(2024, 5, 19);
            var startTime = new TimeSpan(9, 0, 0);
            var endTime = new TimeSpan(17, 0, 0);

            var timeSlot = new TimeSlot(date, startTime, endTime);

            // Act
            int hashCode = timeSlot.GetHashCode();

            // Assert
            Assert.That(hashCode, Is.EqualTo(HashCode.Combine(date, startTime, endTime)));
        }

        [Test]
        public void Create_ShouldReturnNewTimeSlot()
        {
            // Arrange
            var date = new DateTime(2024, 5, 19);
            var startTime = new TimeSpan(9, 0, 0);
            var endTime = new TimeSpan(17, 0, 0);

            // Act
            var timeSlot = TimeSlot.Create(date, startTime, endTime);

            // Assert
            Assert.That(timeSlot.Date, Is.EqualTo(date));
            Assert.That(timeSlot.StartTime, Is.EqualTo(startTime));
            Assert.That(timeSlot.EndTime, Is.EqualTo(endTime));
        }
    }
}
