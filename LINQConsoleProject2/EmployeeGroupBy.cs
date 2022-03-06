using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQConsoleProject2
{
    public class EmployeeGroupBy
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }

        public static List<EmployeeGroupBy> GetAllEmployees()
        {
            return new List<EmployeeGroupBy>()
             {
                new EmployeeGroupBy { ID = 1, Name = "Mark", Gender = "Male",
                                             Department = "IT", Salary = 45000 },
                new EmployeeGroupBy { ID = 2, Name = "Steve", Gender = "Male",
                                             Department = "HR", Salary = 55000 },
                new EmployeeGroupBy { ID = 3, Name = "Ben", Gender = "Male",
                                             Department = "IT", Salary = 65000 },
                new EmployeeGroupBy { ID = 4, Name = "Philip", Gender = "Male",
                                             Department = "IT", Salary = 55000 },
                new EmployeeGroupBy { ID = 5, Name = "Mary", Gender = "Female",
                                             Department = "HR", Salary = 48000 },
                new EmployeeGroupBy { ID = 6, Name = "Valarie", Gender = "Female",
                                             Department = "HR", Salary = 70000 },
                new EmployeeGroupBy { ID = 7, Name = "John", Gender = "Male",
                                             Department = "IT", Salary = 64000 },
                new EmployeeGroupBy { ID = 8, Name = "Pam", Gender = "Female",
                                             Department = "IT", Salary = 54000 },
                new EmployeeGroupBy { ID = 9, Name = "Stacey", Gender = "Female",
                                             Department = "HR", Salary = 84000 },
                new EmployeeGroupBy { ID = 10, Name = "Andy", Gender = "Male",
                                             Department = "IT", Salary = 36000 }
            };
        }
    }
}
