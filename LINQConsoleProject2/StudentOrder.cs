using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQConsoleProject2
{
    public class StudentOrder
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public int TotalMarks { get; set; }

        public static List<StudentOrder> GetAllStudents()
        {
            List<StudentOrder> listStudents = new List<StudentOrder>
            {
                new StudentOrder
                {
                    StudentID= 101,
                    Name = "Tom",
                    TotalMarks = 800
                },
                new StudentOrder
                {
                    StudentID= 102,
                    Name = "Mary",
                    TotalMarks = 900
                },
                new StudentOrder
                {
                    StudentID= 103,
                    Name = "Valarie",
                    TotalMarks = 800
                },
                new StudentOrder
                {
                    StudentID= 104,
                    Name = "John",
                    TotalMarks = 800
                },
            };
            return listStudents;
        }
    }
}

