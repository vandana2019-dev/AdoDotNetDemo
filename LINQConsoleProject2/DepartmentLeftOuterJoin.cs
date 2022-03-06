using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQConsoleProject2
{
    public class DepartmentLeftOuterJoin
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public static List<DepartmentLeftOuterJoin> GetAllDepartments()
        {
            return new List<DepartmentLeftOuterJoin>()
        {
            new DepartmentLeftOuterJoin { ID = 1, Name = "IT"},
            new DepartmentLeftOuterJoin { ID = 2, Name = "HR"},
        };
        }
    }
}
