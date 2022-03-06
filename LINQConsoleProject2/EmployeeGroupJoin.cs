using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQConsoleProject2
{
    public class EmployeeGroupJoin
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int DepartmentID { get; set; }

        public static List<EmployeeGroupJoin> GetAllEmployees()
        {
            return new List<EmployeeGroupJoin>()
        {
            new EmployeeGroupJoin { ID = 1, Name = "Mark", DepartmentID = 1 },
            new EmployeeGroupJoin { ID = 2, Name = "Steve", DepartmentID = 2 },
            new EmployeeGroupJoin { ID = 3, Name = "Ben", DepartmentID = 1 },
            new EmployeeGroupJoin { ID = 4, Name = "Philip", DepartmentID = 1 },
            new EmployeeGroupJoin { ID = 5, Name = "Mary", DepartmentID = 2 },
            new EmployeeGroupJoin { ID = 6, Name = "Valarie", DepartmentID = 2 },
            new EmployeeGroupJoin { ID = 7, Name = "John", DepartmentID = 1 },
            new EmployeeGroupJoin { ID = 8, Name = "Pam", DepartmentID = 1 },
            new EmployeeGroupJoin { ID = 9, Name = "Stacey", DepartmentID = 2 },
            new EmployeeGroupJoin { ID = 10, Name = "Andy", DepartmentID = 1}
        };

        }
    }
}
