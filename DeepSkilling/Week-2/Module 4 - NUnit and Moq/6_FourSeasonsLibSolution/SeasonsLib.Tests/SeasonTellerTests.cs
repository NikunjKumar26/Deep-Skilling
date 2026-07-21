using System;
using NUnit.Framework;
using SeasonsLib;

namespace SeasonsLib.Tests
{
    [TestFixture]
    public class SeasonTellerTests
    {
        private SeasonTeller _seasonTeller;

        [SetUp]
        public void SetUp()
        {
            _seasonTeller = new SeasonTeller();
        }

        // Test Case Source Method
        public static object[] SeasonTestCases =
        {
            new object[] { "February", "Spring" },
            new object[] { "March", "Spring" },
            new object[] { "April", "Summer" },
            new object[] { "May", "Summer" },
            new object[] { "June", "Summer" },
            new object[] { "July", "Monsoon" },
            new object[] { "August", "Monsoon" },
            new object[] { "September", "Monsoon" },
            new object[] { "October", "Autumn" },
            new object[] { "November", "Autumn" },
            new object[] { "December", "Winter" },
            new object[] { "January", "Winter" },
            new object[] { "Unknown", "Invalid Season" }
        };

        [Test, TestCaseSource(nameof(SeasonTestCases))]
        public void DisplaySeasonBy_ValidAndInvalidMonths_ReturnsExpectedSeason(string monthName, string expectedSeason)
        {
            // Act
            string actual = _seasonTeller.DisplaySeasonBy(monthName);

            // Assert
            Assert.That(actual, Is.EqualTo(expectedSeason));
        }
    }
}
