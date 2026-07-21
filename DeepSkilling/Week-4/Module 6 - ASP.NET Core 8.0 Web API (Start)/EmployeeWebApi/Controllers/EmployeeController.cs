using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EmployeeWebApi.Models;

namespace EmployeeWebApi.Controllers
{
    // Document 2: Changed from Employee to Emp
    [Route("api/Emp")]
    [ApiController]
    // Document 5: Require Authorization (Role POC and Admin)
    [Authorize(Roles = "Admin,POC")]
    public class EmployeeController : ControllerBase
    {
        // Static hardcoded list as required by Doc 3 & 4
        private static List<Employee> _employees = GetStandardEmployeeList();

        private static List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee { Id = 1, Name = "John", Salary = 50000, Permanent = true },
                new Employee { Id = 2, Name = "Smith", Salary = 60000, Permanent = false },
                new Employee { Id = 3, Name = "Mark", Salary = 70000, Permanent = true }
            };
        }

        // Document 3: GET Action returning list
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<List<Employee>> Get()
        {
            // Note: to test CustomExceptionFilter, we could throw an exception here:
            // throw new System.Exception("Test exception for CustomExceptionFilter");
            return Ok(_employees);
        }

        // Document 4: PUT Action to update
        [HttpPut("{id}")]
        public ActionResult<Employee> Put(int id, [FromBody] Employee input)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return BadRequest("Invalid employee id");
            }

            // Update details
            employee.Name = input.Name;
            employee.Salary = input.Salary;
            employee.Permanent = input.Permanent;
            employee.Department = input.Department;
            employee.Skills = input.Skills;
            employee.DateOfBirth = input.DateOfBirth;

            return Ok(employee);
        }
    }
}
