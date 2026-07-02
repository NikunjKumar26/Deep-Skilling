using NUnit.Framework;
using CollectionsLib;
using System.Linq;

namespace CollectionsLib.Tests
{
    [TestFixture]
    public class CollectionsManagerTests
    {
        private CollectionsManager manager;

        [SetUp]
        public void Setup()
        {
            manager = new CollectionsManager();
        }

        // Scenario 1
        [Test]
        public void GetEmployees_NoNullValues_ReturnsTrue()
        {
            var employees = manager.GetEmployees();

            CollectionAssert.AllItemsAreNotNull(employees);
        }

        // Scenario 2
        [Test]
        public void GetEmployees_Employee100Exists_ReturnsTrue()
        {
            var employees = manager.GetEmployees();

            Assert.That(employees.Any(e => e.Id == 100), Is.True);
        }

        // Scenario 3
        [Test]
        public void GetEmployees_AllEmployeesUnique_ReturnsTrue()
        {
            var employees = manager.GetEmployees();

            Assert.That(
                employees.Select(e => e.Id).Distinct().Count(),
                Is.EqualTo(employees.Count)
            );
        }

        // Scenario 4
        [Test]
        public void BothCollections_AreEqual_ReturnsTrue()
        {
            var employees1 = manager.GetEmployees();
            var employees2 = manager.GetEmployeesWhoJoinedInPreviousYears();

            CollectionAssert.AreEqual(employees1, employees2);
        }
    }
}