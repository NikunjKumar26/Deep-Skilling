using System;
using System.Collections.Generic;
using NUnit.Framework;
using CollectionsLib;
using System.Linq;

namespace CollectionsLib.Tests
{
    [TestFixture]
    public class EmployeeManagerTests
    {
        private EmployeeManager _manager;

        [SetUp]
        public void SetUp()
        {
            _manager = new EmployeeManager();
        }

        [Test]
        public void GetEmployees_NoNullValue_ReturnsValidCollection()
        {
            // Act
            List<Employee> employees = _manager.GetEmployees();

            // Assert
            Assert.That(employees, Is.All.Not.Null);
        }

        [Test]
        public void GetEmployees_VerifyEmployeeId100Exists_ReturnsTrue()
        {
            // Act
            List<Employee> employees = _manager.GetEmployees();

            // Assert
            Assert.That(employees.Any(e => e.EmpId == 100), Is.True);
            // Alternatively using NUnit syntax:
            // Assert.That(employees, Has.Some.Property("EmpId").EqualTo(100));
        }

        [Test]
        public void GetEmployees_ReturnsOnlyUniqueEmployees_ReturnsUniqueList()
        {
            // Act
            List<Employee> employees = _manager.GetEmployees();

            // Assert
            // Since we overrode Equals and GetHashCode in Employee using EmpId,
            // this will ensure all employees have unique IDs.
            Assert.That(employees, Is.Unique);
        }

        [Test]
        public void GetEmployees_CompareWithPreviousYears_BothCollectionsAreEquivalent()
        {
            // Act
            List<Employee> allEmployees = _manager.GetEmployees();
            List<Employee> previousYearsEmployees = _manager.GetEmployeesWhoJoinedInPreviousYears();

            // Assert - Classic Model
            CollectionAssert.AreEquivalent(allEmployees, previousYearsEmployees);

            // Assert - Constraint Model
            Assert.That(allEmployees, Is.EquivalentTo(previousYearsEmployees));
        }
    }
}
