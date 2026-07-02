using System.Collections.Generic;

namespace CollectionsLib
{
    public class CollectionsManager
    {
        public List<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee { Id = 100, Name = "Ram" },
                new Employee { Id = 101, Name = "Krishna" },
                new Employee { Id = 102, Name = "Sai" }
            };
        }

        public List<Employee> GetEmployeesWhoJoinedInPreviousYears()
        {
            return new List<Employee>
            {
                new Employee { Id = 100, Name = "Ram" },
                new Employee { Id = 101, Name = "Krishna" },
                new Employee { Id = 102, Name = "Sai" }
            };
        }
    }
}