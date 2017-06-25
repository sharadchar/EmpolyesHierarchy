using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;

namespace EmployesHierarchy
{
    [DebuggerDisplay("{EmployeeName}")]
    public class Employee
    {
        public string EmployeeName { get; set; }
        public int Id { get; set; }
        public int? ManagerId { get; set; }
        public List<Employee> Team { get; set; }

        public Employee()
        {
            Team = new List<Employee>();
        }

        public IEnumerable<Employee> GetSubordinates(IEnumerable<Employee> employees, int empID)
        {
            return from emp in employees
                   where emp.ManagerId == empID
                   select emp;
        }
    }
}
