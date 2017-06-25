using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace EmployesData
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

        /// <summary>
        /// Genetate the hierarchy of the employes under the ManagerId provided
        /// </summary>
        /// <param name="managerId">Id if the Employee</param>
        /// <returns>Employe Object Containing All The SubEmployes</returns>
        public Employee GetHierarchy(int managerId)
        {
            Employee employeeExist = _employees.FirstOrDefault<Employee>(x => x.Id == managerId);
            if (employeeExist != null)
            {
                Employee managerHierachy = new Employee();
                managerHierachy = employeeExist;
                //if()

                List<Employee> listOfSubordinates = GetSubordinatesHierarchy(managerId);
                if (listOfSubordinates.Any())
                {
                    managerHierachy.Team = listOfSubordinates;
                }
                return managerHierachy;
            }
            else
            {
                return null;
            }
        }

        private List<Employee> GetSubordinatesHierarchy(int managerId)
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
