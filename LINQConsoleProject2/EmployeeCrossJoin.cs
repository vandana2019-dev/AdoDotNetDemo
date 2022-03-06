using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQConsoleProject2
{
    public class EmployeeCrossJoin
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int DepartmentID { get; set; }

        public static List<EmployeeCrossJoin> GetAllEmployees()
        {
            return new List<EmployeeCrossJoin>()
            {
            new EmployeeCrossJoin { ID = 1, Name = "Mark", DepartmentID = 1 },
            new EmployeeCrossJoin { ID = 2, Name = "Steve", DepartmentID = 2 },
            new EmployeeCrossJoin { ID = 3, Name = "Ben", DepartmentID = 1 },
            new EmployeeCrossJoin { ID = 4, Name = "Philip", DepartmentID = 1 },
            new EmployeeCrossJoin { ID = 5, Name = "Mary", DepartmentID = 2 },
           };
        }
    }


}
