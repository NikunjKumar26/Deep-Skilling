using System;
using NUnit.Framework;
using LeapYearCalculatorLib;

namespace LeapYearCalculatorLib.Tests
{
    [TestFixture]
    public class LeapYearCalculatorTests
    {
        private LeapYearCalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new LeapYearCalculator();
        }

        [TestCase(2000, 1)]
        [TestCase(2024, 1)]
        [TestCase(2023, 0)]
        [TestCase(1900, 0)]
        public void IsLeapYear_ValidYear_ReturnsCorrectResult(int year, int expected)
        {
            // Act
            int actual = _calculator.IsLeapYear(year);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1752, -1)]
        [TestCase(10000, -1)]
        [TestCase(0, -1)]
        public void IsLeapYear_InvalidYear_ReturnsMinusOne(int year, int expected)
        {
            // Act
            int actual = _calculator.IsLeapYear(year);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
