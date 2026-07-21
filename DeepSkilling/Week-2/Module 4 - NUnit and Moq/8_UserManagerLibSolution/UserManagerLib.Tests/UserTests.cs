using System;
using NUnit.Framework;
using UserManagerLib;

namespace UserManagerLib.Tests
{
    [TestFixture]
    public class UserTests
    {
        private User _userComponent;

        [SetUp]
        public void SetUp()
        {
            _userComponent = new User();
        }

        [Test]
        public void CreateUser_ValidPanCard_CreatesUserSuccessfully()
        {
            // Arrange
            User newUser = new User 
            { 
                FirstName = "John", 
                LastName = "Doe", 
                PANCardNo = "ABCDE1234F" 
            };

            // Act & Assert
            // Assert.DoesNotThrow ensures happy path completes successfully without exceptions.
            Assert.DoesNotThrow(() => _userComponent.CreateUser(newUser));
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateUser_EmptyOrNullPanCard_ThrowsNullReferenceException(string panCard)
        {
            // Arrange
            User newUser = new User 
            { 
                FirstName = "John", 
                LastName = "Doe", 
                PANCardNo = panCard 
            };

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => _userComponent.CreateUser(newUser));
        }

        [TestCase("ABCDE")]
        [TestCase("ABCDE1234F5")]
        public void CreateUser_InvalidLengthPanCard_ThrowsFormatException(string panCard)
        {
            // Arrange
            User newUser = new User 
            { 
                FirstName = "John", 
                LastName = "Doe", 
                PANCardNo = panCard 
            };

            // Act & Assert
            Assert.Throws<FormatException>(() => _userComponent.CreateUser(newUser));
        }
    }
}
