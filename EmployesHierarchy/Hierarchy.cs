using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EmployesHierarchy
{
    public class Hierarchy
    {
        private List<Employee> _employees;
        private Employee _objEmp;

        public Hierarchy(Employee objEmp, SetupEmployes _setupData)
        {
            _employees = _setupData.GetEmployes();
            _objEmp = objEmp;
        }

        public Employee GetHierarchy(int managerId)
        {
            Employee managerHierachy = new Employee();
            managerHierachy = _employees.FirstOrDefault<Employee>(x => x.Id == managerId);
            List<Employee> listOfSubordinates = GetSubordinatesHierarchy(managerId);
            if (listOfSubordinates.Any())
            {
                managerHierachy.Team = listOfSubordinates;
            }
            return managerHierachy;
        }

        public List<Employee> GetSubordinatesHierarchy(int managerId)
        {
            var subEmp = new List<Employee>(_objEmp.GetSubordinates(_employees, managerId));
            if (subEmp != null && subEmp.Any())
            {
                foreach (Employee emp in subEmp)
                {
                    emp.Team = GetSubordinatesHierarchy(emp.Id);
                }
            }
            return subEmp;
        }
    }
}
