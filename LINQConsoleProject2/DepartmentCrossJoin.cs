using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQConsoleProject2
{
    public class DepartmentCrossJoin
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public static List<DepartmentCrossJoin> GetAllDepartments()
        {
            return new List<DepartmentCrossJoin>()
            {
            new DepartmentCrossJoin { ID = 1, Name = "IT"},
            new DepartmentCrossJoin { ID = 2, Name = "HR"},
            };
        }
    }
}
