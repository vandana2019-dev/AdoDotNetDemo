using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQConsoleProject2
{
    public class EmployeeGroupByMultipleKey
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }

        public static List<EmployeeGroupByMultipleKey> GetAllEmployees()
        {
            return new List<EmployeeGroupByMultipleKey>()
        {
            new EmployeeGroupByMultipleKey { ID = 1, Name = "Mark", Gender = "Male",
                                         Department = "IT" },
            new EmployeeGroupByMultipleKey { ID = 2, Name = "Steve", Gender = "Male",
                                         Department = "HR" },
            new EmployeeGroupByMultipleKey { ID = 3, Name = "Ben", Gender = "Male",
                                         Department = "IT" },

            new EmployeeGroupByMultipleKey { ID = 4, Name = "Philip", Gender = "Male",
                                         Department = "IT" },
            new EmployeeGroupByMultipleKey { ID = 5, Name = "Mary", Gender = "Female",
                                         Department = "HR" },
            new EmployeeGroupByMultipleKey { ID = 6, Name = "Valarie", Gender = "Female",
                                         Department = "HR" },
            new EmployeeGroupByMultipleKey { ID = 7, Name = "John", Gender = "Male",
                                         Department = "IT" },
            new EmployeeGroupByMultipleKey { ID = 8, Name = "Pam", Gender = "Female",
                                         Department = "IT" },
            new EmployeeGroupByMultipleKey { ID = 9, Name = "Stacey", Gender = "Female",
                                         Department = "HR" },
            new EmployeeGroupByMultipleKey { ID = 10, Name = "Andy", Gender = "Male",
                                         Department = "IT" },

            };
        }
    }
}
