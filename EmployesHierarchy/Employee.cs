using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EmployesHierarchy
{
    public class Employee
    {
        public string EmployeeName { get; set; }
        public int Id { get; set; }
        public int? ManagerId { get; set; }

        public IEnumerable<Employee> GetSubordinates(IEnumerable<Employee> employees, int empID)
        {
            return from emp in employees
                   where emp.ManagerId == empID
                   select emp;
        }
    }
}
