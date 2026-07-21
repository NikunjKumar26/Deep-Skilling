using System;
using NUnit.Framework;
using Moq;
using PlayersManagerLib;

namespace PlayerManager.Tests
{
    [TestFixture]
    public class PlayerManagerTests
    {
        private Mock<IPlayerMapper> _playerMapperMock;

        [OneTimeSetUp]
        public void Init()
        {
            _playerMapperMock = new Mock<IPlayerMapper>();
        }

        [Test]
        public void RegisterNewPlayer_NewName_ReturnsPlayerWithCorrectAttributes()
        {
            // Arrange
            string playerName = "Virat Kohli";
            _playerMapperMock.Setup(m => m.IsPlayerNameExistsInDb(playerName)).Returns(false);

            // Act
            Player result = Player.RegisterNewPlayer(playerName, _playerMapperMock.Object);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo(playerName));
            Assert.That(result.Age, Is.EqualTo(23));
            Assert.That(result.Country, Is.EqualTo("India"));
            Assert.That(result.NoOfMatches, Is.EqualTo(30));
        }

        [Test]
        public void RegisterNewPlayer_ExistingName_ThrowsArgumentException()
        {
            // Arrange
            string playerName = "Sachin";
            _playerMapperMock.Setup(m => m.IsPlayerNameExistsInDb(playerName)).Returns(true);

            // Act & Assert
            // Using Assert.Throws as it is the standard in NUnit compared to [ExpectedException] which is obsolete
            var ex = Assert.Throws<ArgumentException>(() => Player.RegisterNewPlayer(playerName, _playerMapperMock.Object));
            Assert.That(ex.Message, Is.EqualTo("Player name already exists."));
        }
    }
}
