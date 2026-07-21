using System;
using NUnit.Framework;
using CalcLibrary;

namespace CalcLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private SimpleCalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new SimpleCalculator();
        }

        [TearDown]
        public void TearDown()
        {
            _calculator = null;
        }

        // --- Question 1: Addition Test ---
        [TestCase(10, 5, 15)]
        [TestCase(-5, 5, 0)]
        [TestCase(0, 0, 0)]
        public void Addition_ValidInputs_ReturnsExpectedResult(double a, double b, double expected)
        {
            double actual = _calculator.Addition(a, b);
            Assert.That(actual, Is.EqualTo(expected));
        }

        // --- Question 2: Subtraction, Multiplication, Division and Void Methods ---
        [TestCase(10, 5, 5)]
        [TestCase(-5, 5, -10)]
        public void Subtraction_ValidInputs_ReturnsExpectedResult(double a, double b, double expected)
        {
            double actual = _calculator.Subtraction(a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(10, 5, 50)]
        [TestCase(-5, 5, -25)]
        public void Multiplication_ValidInputs_ReturnsExpectedResult(double a, double b, double expected)
        {
            double actual = _calculator.Multiplication(a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(10, 5, 2)]
        [TestCase(-10, 5, -2)]
        public void Division_ValidInputs_ReturnsExpectedResult(double a, double b, double expected)
        {
            double actual = _calculator.Division(a, b);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Division_ByZero_ThrowsException()
        {
            try
            {
                _calculator.Division(10, 0);
                Assert.Fail("Division by zero");
            }
            catch (ArgumentException)
            {
                // Expected exception
            }
        }

        [Test]
        public void TestAddAndClear()
        {
            // Invoke Addition
            _calculator.Addition(10, 5);
            
            // Verify expected result
            Assert.AreEqual(15, _calculator.GetResult);
            
            // Invoke AllClear
            _calculator.AllClear();
            
            // Verify result is 0
            Assert.AreEqual(0, _calculator.GetResult);
        }
    }
}
