using System;
using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using MagicFilesLib;

namespace DirectoryExplorer.Tests
{
    [TestFixture]
    public class DirectoryExplorerTests
    {
        private Mock<IDirectoryExplorer> _directoryExplorerMock;
        private readonly string _file1 = "file.txt";
        private readonly string _file2 = "file2.txt";

        [OneTimeSetUp]
        public void Init()
        {
            _directoryExplorerMock = new Mock<IDirectoryExplorer>();
        }

        [Test]
        public void GetFiles_ValidPath_ReturnsMockedFiles()
        {
            // Arrange
            string path = @"C:\Temp";
            var expectedFiles = new List<string> { _file1, _file2 };
            _directoryExplorerMock.Setup(m => m.GetFiles(path)).Returns(expectedFiles);

            // Act
            var actual = _directoryExplorerMock.Object.GetFiles(path);

            // Assert
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Count, Is.EqualTo(2));
            Assert.That(actual, Does.Contain(_file1));
        }
    }
}
