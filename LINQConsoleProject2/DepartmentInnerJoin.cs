using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQConsoleProject2
{
    public class DepartmentInnerJoin
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public static List<DepartmentInnerJoin> GetAllDepartments()
        {
            return new List<DepartmentInnerJoin>()
           {
                new DepartmentInnerJoin { ID = 1, Name = "IT"},
                new DepartmentInnerJoin { ID = 2, Name = "HR"},
                new DepartmentInnerJoin { ID = 3, Name = "Payroll"},
            };
        }
    }
}
