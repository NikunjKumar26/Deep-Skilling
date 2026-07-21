using System;
using NUnit.Framework;
using UtilLib;

namespace UtilLib.Tests
{
    [TestFixture]
    public class UrlHostNameParserTests
    {
        private UrlHostNameParser _parser;

        [SetUp]
        public void SetUp()
        {
            _parser = new UrlHostNameParser();
        }

        [Test]
        public void ParseHostName_ValidHttpUrl_ReturnsHostName()
        {
            // Arrange
            string url = "http://www.google.com/search";

            // Act
            string actual = _parser.ParseHostName(url);

            // Assert
            Assert.That(actual, Is.EqualTo("www.google.com"));
        }

        [Test]
        public void ParseHostName_ValidHttpsUrl_ReturnsHostName()
        {
            // Arrange
            string url = "https://www.microsoft.com/en-us";

            // Act
            string actual = _parser.ParseHostName(url);

            // Assert
            Assert.That(actual, Is.EqualTo("www.microsoft.com"));
        }

        [Test]
        public void ParseHostName_InvalidUrlFormat_ThrowsFormatException()
        {
            // Arrange
            string url = "ftp://fileserver.local/file";

            // Act & Assert
            Assert.Throws<FormatException>(() => _parser.ParseHostName(url));
        }
    }
}
