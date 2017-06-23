using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EmployesHierarchy
{
    public class CreateManagerHierarchy
    {
        private static StringBuilder tabs = new StringBuilder("\t");
        private static string tab = "\t";
        private List<Employee> employees;
        private Employee _objEmp;

        public CreateManagerHierarchy(Employee objEmp, SetupEmployes dataObj)
        {
            employees = dataObj.GetEmployes();
            _objEmp = objEmp;
        }

        /// <summary>
        /// This method create the employes hierarchy
        /// </summary>
        public void Create()
        {
            try
            {
                int managerId = readInputId();

                List<Employee> subordinates = new List<Employee>(_objEmp.GetSubordinates(employees, managerId));

                Console.WriteLine(employees.FirstOrDefault(x => x.Id == managerId).EmployeeName);

                foreach (Employee obj in subordinates)
                {
                    Console.WriteLine(tabs + " | " + obj.EmployeeName);
                    ListSubUser(_objEmp, obj.Id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " - " + ex.InnerException.Message);
                Console.ReadLine();
            }
            Console.ReadLine();
        }

        private int readInputId()
        {
            Console.WriteLine("Please Enter The ManagerId");
            string inputID = Console.ReadLine();
            int empId;
            bool result = int.TryParse(inputID, out empId);
            if (result == false)
            {
                Console.WriteLine("ManagerID Not Valid!!");
                return readInputId();
            }
            return empId;
        }

        private void ListSubUser(Employee objEmp, int emploId)
        {
            var level1Emp = new List<Employee>(objEmp.GetSubordinates(employees, emploId));
            if (level1Emp != null && level1Emp.Any())
            {
                tabs.Append("\t");
                
                foreach (Employee emp in level1Emp)
                {
                    Console.WriteLine(tabs + " | " + emp.EmployeeName);
                    ListSubUser(objEmp, emp.Id);
                }

                tabs.Remove(tabs.Length - 1, tab.Length);
            }
        }
    }
}
