using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQConsoleProject2
{
    public class EmployeeInnerJoin
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int DepartmentID { get; set; }

        public static List<EmployeeInnerJoin> GetAllEmployees()
        {
            return new List<EmployeeInnerJoin>()
            {
                new EmployeeInnerJoin { ID = 1, Name = "Mark", DepartmentID = 1 },
                new EmployeeInnerJoin { ID = 2, Name = "Steve", DepartmentID = 2 },
                new EmployeeInnerJoin { ID = 3, Name = "Ben", DepartmentID = 1 },
                new EmployeeInnerJoin { ID = 4, Name = "Philip", DepartmentID = 1 },
                new EmployeeInnerJoin { ID = 5, Name = "Mary", DepartmentID = 2 },
                new EmployeeInnerJoin { ID = 6, Name = "Valarie", DepartmentID = 2 },
                new EmployeeInnerJoin { ID = 7, Name = "John", DepartmentID = 1 },
                new EmployeeInnerJoin { ID = 8, Name = "Pam", DepartmentID = 1 },
                new EmployeeInnerJoin { ID = 9, Name = "Stacey", DepartmentID = 2 },
                new EmployeeInnerJoin { ID = 10, Name = "Andy"}
            };
        }
    }
}
