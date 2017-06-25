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
                //Get the ManagerId To Generate the Hierarchy
                int managerId = readInputId();
                //Get the Employee Hierarchy                
                Employee objEmp = _employeHierarchy.GetHierarchy(managerId);
                //Create the Manager hierarch at console
                CreateHierarchy(objEmp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " - " + ex.InnerException.Message);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Creates the Employes structure at Console
        /// </summary>
        /// <param name="objEmp"></param>
        private void CreateHierarchy(Employee objEmp)
        {
            try
            {
                Console.WriteLine(objEmp.EmployeeName);

                foreach (Employee subEmp in objEmp.Team)
                {
                    Console.WriteLine(tabs + " | " + subEmp.EmployeeName);
                    ListSubEmpo(subEmp);
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

        /// <summary>
        /// Gets The ManagerId from the user
        /// </summary>
        /// <returns>Returs the id recieved from the user</returns>
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

        /// <summary>
        /// List The Sub Employes At The Console
        /// </summary>
        /// <param name="emplo">Employe entity</param>
        private void ListSubEmpo(Employee emplo)
        {
            if (emplo != null && emplo.Team != null && emplo.Team.Any())
            {
                tabs.Append("\t");                
                foreach (Employee emp in emplo.Team)
                {
                    Console.WriteLine(tabs + " | " + emp.EmployeeName);
                    ListSubEmpo(emp);
                }
                tabs.Remove(tabs.Length - 1, tab.Length);
            }
        }
    }
}
