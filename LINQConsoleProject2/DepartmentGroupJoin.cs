using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQConsoleProject2
{
    public class DepartmentGroupJoin
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public static List<DepartmentGroupJoin> GetAllDepartments()
        {
            return new List<DepartmentGroupJoin>()
        {
            new DepartmentGroupJoin { ID = 1, Name = "IT"},
            new DepartmentGroupJoin { ID = 2, Name = "HR"},
            new DepartmentGroupJoin { ID = 3, Name = "Payroll"},
        };
        }
    }
}
