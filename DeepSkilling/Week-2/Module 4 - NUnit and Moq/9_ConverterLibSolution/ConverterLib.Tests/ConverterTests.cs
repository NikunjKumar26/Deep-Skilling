using System;
using NUnit.Framework;
using Moq;
using ConverterLib;
using CurrencyConverterApp;

namespace ConverterLib.Tests
{
    [TestFixture]
    public class ConverterTests
    {
        private Mock<IDollarToEuroExchangeRateFeed> _exchangeRateFeedMock;
        private Converter _converter;

        [SetUp]
        public void SetUp()
        {
            _exchangeRateFeedMock = new Mock<IDollarToEuroExchangeRateFeed>();
            _converter = new Converter(_exchangeRateFeedMock.Object);
        }

        [Test]
        public void USDToEuro_ConvertAmount_ReturnsExpectedEuroAmount()
        {
            // Arrange
            double dollarAmount = 100;
            double mockRate = 0.92;
            _exchangeRateFeedMock.Setup(feed => feed.GetActualUSDollarValue()).Returns(mockRate);

            // Act
            double actual = _converter.USDToEuro(dollarAmount);

            // Assert
            Assert.That(actual, Is.EqualTo(92));
        }
    }
}
