using System.Collections.Generic;

namespace EmployesHierarchy
{
    public class SetupEmployes
    {
        //Setup data
        public List<Employee> GetEmployes()
        {
            //This can have logic to get the data from database
            
            return new List<Employee>()
            {
                new Employee{EmployeeName="Alan",Id=100,ManagerId=150},
                new Employee{EmployeeName="Martin",Id=220,ManagerId=100},
                new Employee{EmployeeName="Jamie",Id=150,ManagerId=null},
                new Employee{EmployeeName="Alex",Id=274,ManagerId=100},
                new Employee{EmployeeName="AlexA",Id=275,ManagerId=274},
                new Employee{EmployeeName="AlexB",Id=276,ManagerId=274},
                new Employee{EmployeeName="AlexB1",Id=277,ManagerId=276},
                new Employee{EmployeeName="Steve",Id=400,ManagerId=150},
                new Employee{EmployeeName="David",Id=190,ManagerId=400},
                new Employee{EmployeeName="DavidA",Id=191,ManagerId=190},
            };
        }
    }
}
