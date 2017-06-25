using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployesData;

namespace EmployesHierarchy
{
    public static class Program
    {
        /// <summary>
        /// Main method is respponsible of calling the Create Method of CreateManagerHierarchy class
        /// It also injects the dependent Employee and SetupEmployes class to it.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Employee objEmp = new Employee();
            SetupEmployes dataObj = new SetupEmployes();

            CreateManagerHierarchy objCreateManagerHierarchy = new CreateManagerHierarchy(objEmp, dataObj);
            
            objCreateManagerHierarchy.Create();            
        }

        
    }
}