using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQConsoleProject2
{
    public class EmployeeLeftOuterJoin
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int DepartmentID { get; set; }

        public static List<EmployeeLeftOuterJoin> GetAllEmployees()
        {
            return new List<EmployeeLeftOuterJoin>()
            {
                new EmployeeLeftOuterJoin { ID = 1, Name = "Mark", DepartmentID = 1 },
                new EmployeeLeftOuterJoin { ID = 2, Name = "Steve", DepartmentID = 2 },
                new EmployeeLeftOuterJoin { ID = 3, Name = "Ben", DepartmentID = 1 },
                new EmployeeLeftOuterJoin { ID = 4, Name = "Philip", DepartmentID = 1 },
                new EmployeeLeftOuterJoin { ID = 5, Name = "Mary" }
            };
        }
    }

}
