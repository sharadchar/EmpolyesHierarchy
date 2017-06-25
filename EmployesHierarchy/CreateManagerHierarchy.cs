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

        private List<Employee> _employees;
        private Employee _objEmp;
        private Hierarchy _employeHierarchy;

        public CreateManagerHierarchy(Employee objEmp, SetupEmployes setupEmp)
        {
            _objEmp = objEmp;
            _employees = setupEmp.GetEmployes();            
            _employeHierarchy = new Hierarchy(objEmp, setupEmp);            
        }

        /// <summary>
        /// This method create the employes hierarchy
        /// </summary>
        public void Create()
        {
            try
            {
                int managerId = readInputId();
                               
                Employee objEmp = _employeHierarchy.GetHierarchy(managerId);

                CreateHierarchy(objEmp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " - " + ex.InnerException.Message);
                Console.ReadLine();
            }
            Console.ReadLine();
        }

        private void CreateHierarchy(Employee objEmp)
        {
            try
            {
                Console.WriteLine(objEmp.EmployeeName);

                foreach (Employee subEmp in objEmp.Team)
                {
                    Console.WriteLine(tabs + " | " + subEmp.EmployeeName);
                    ListSubUser(subEmp);
                }

                Console.WriteLine("Want to exit (Y/N)");
                string value = Console.ReadLine();
                if(value.ToUpper() == "N" )
                {
                    Create();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
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



        private void ListSubUser(Employee emplo)
        {
            //var level1Emp = new List<Employee>(_objEmp.GetSubordinates(_employees, emplo));
            if (emplo != null && emplo.Team != null && emplo.Team.Any())
            {
                tabs.Append("\t");
                
                foreach (Employee emp in emplo.Team)
                {
                    Console.WriteLine(tabs + " | " + emp.EmployeeName);
                    ListSubUser(emp);
                }

                tabs.Remove(tabs.Length - 1, tab.Length);
            }
        }
    }
}
