using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQConsoleProject2
{
    public class StudentPaging
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public int TotalMarks { get; set; }

        public static List<StudentPaging> GetAllStudetns()
        {
            List<StudentPaging> listStudents = new List<StudentPaging>
            {
                new StudentPaging { StudentID= 101, Name = "Tom", TotalMarks = 800 },
                new StudentPaging { StudentID= 102, Name = "Mary", TotalMarks = 900 },
                new StudentPaging { StudentID= 103, Name = "Pam", TotalMarks = 800 },
                new StudentPaging { StudentID= 104, Name = "John", TotalMarks = 800 },
                new StudentPaging { StudentID= 105, Name = "John", TotalMarks = 800 },
                new StudentPaging { StudentID= 106, Name = "Brian", TotalMarks = 700 },
                new StudentPaging { StudentID= 107, Name = "Jade", TotalMarks = 750 },
                new StudentPaging { StudentID= 108, Name = "Ron", TotalMarks = 850 },
                new StudentPaging { StudentID= 109, Name = "Rob", TotalMarks = 950 },
                new StudentPaging { StudentID= 110, Name = "Alex", TotalMarks = 750 },
                new StudentPaging { StudentID= 111, Name = "Susan", TotalMarks = 860 },
            };

            return listStudents;
        }
    }
}
